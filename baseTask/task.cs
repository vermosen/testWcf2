using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace baseTask
{
    public delegate void logMessageDlg(Guid id, string message);
    public delegate void taskSuccessDlg(Guid id, bool result);
    public abstract class task
    {
        protected logMessageDlg     logDlg_ ;
        protected taskSuccessDlg    resDlg_ ;
        protected Guid              id_     ;

        public task(Guid id, logMessageDlg logDlg, taskSuccessDlg resDlg)
        {
            logDlg_ = logDlg;
            resDlg_ = resDlg;
            id_     = id    ;
        }

        public abstract void loadPreferences(string xmlPath);
        public abstract void run();
    }
}