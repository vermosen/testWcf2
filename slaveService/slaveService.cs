using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using baseTask;
using System.Reflection;

namespace slaveService
{
    public partial class slaveService : ServiceBase
    {
        private Mutex logMutex_;

        public slaveService()
        {
            logMutex_ = new Mutex();
            InitializeComponent();
        }

#if DEBUG
        public void startStopProcedure(string[] args)
        {
            this.OnStart(args);
            Thread.Sleep(15000);
            this.OnStop();
        }
#endif
        protected override void OnStart(string[] args)
        {
            // start listening service here
            addTask(@"C:\Git\testWcf2\exampleTask\bin\Debug\derivedTask.dll", "derivedTask.exampleTask1");
            addTask(@"C:\Git\testWcf2\exampleTask\bin\Debug\derivedTask.dll", "derivedTask.exampleTask2");
        }

        protected override void OnStop()
        {
            // stop listening wcf service here
        }

        protected void addTask(string dllPath, string classType)
        {
            // add a task
            try
            {
                Assembly assembly = Assembly.LoadFrom(dllPath);
                Type type = assembly.GetType(classType);

                object[] args = new object[3];
                args[0] = Guid.NewGuid();
                args[1] = new logMessageDlg(this.log);
                args[2] = new taskSuccessDlg(this.getTaskResult);

                task newTask = (task)Activator.CreateInstance(type, args);

                Thread t = new Thread(new ThreadStart(newTask.run));

                t.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception: {0}", ex.Message);
                throw;
            }

        }

        protected void getTaskResult(Guid id, bool results)
        {
            #region critical section
            lock (logMutex_)
            {
                Console.WriteLine("task {0} finished with result: {1}", id, results);
            }

            #endregion
        }

        protected void log(Guid id, string message)
        {
            #region critical section
            lock (logMutex_)
            {
                Console.WriteLine("id {0} send message: {1}", id, message);
            }
            #endregion
        }
    }
}
