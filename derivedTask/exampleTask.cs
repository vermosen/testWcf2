using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baseTask;

namespace derivedTask
{
    public class exampleTask1 : task
    {
        public exampleTask1(Guid id, logMessageDlg logDlg, taskSuccessDlg resDlg) : base(id, logDlg, resDlg) { }
        public override void loadPreferences(string xmlPath)
        {
            logDlg_(id_, "where is my xml ? Here it is: " + xmlPath);
        }

        public override void run()
        {
            try
            {
                logDlg_(id_, "running task of type 1...");
                resDlg_(id_, true);
            }
            catch (Exception ex)
            {
                logDlg_(id_, "something wrong happened: " + ex.Message);
                resDlg_(id_, false);
            }           
        }
    }

    public class exampleTask2 : task
    {
        public exampleTask2(Guid id, logMessageDlg logDlg, taskSuccessDlg resDlg) : base(id, logDlg, resDlg) { }
        public override void loadPreferences(string xmlPath)
        {
            logDlg_(id_, "where is my xml ? Here it is: " + xmlPath);
        }

        public override void run()
        {
            try
            {
                logDlg_(id_, "running task of type 2...");
                resDlg_(id_, true);
            }
            catch (Exception ex)
            {
                logDlg_(id_, "something wrong happened: " + ex.Message);
                resDlg_(id_, false);
            }
        }
    }
}
