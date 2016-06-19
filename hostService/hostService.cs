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
using System.Reflection;

namespace hostService
{
    // host the wcf service and start jobs
    public partial class hostService : ServiceBase
    {
        public hostService()
        {
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

        }

        protected override void OnStop()
        {
            // stop listening wcf service here
        }
    }
}
