using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace hostService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            #if DEBUG
            hostService s = new hostService();
            s.startStopProcedure(null);
            #else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new hostService()
            };
            ServiceBase.Run(ServicesToRun);
            #endif
        }
    }
}
