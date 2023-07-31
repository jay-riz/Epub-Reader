using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp3.OtherFuncs
{
    public static class Logging
    {
        static public void LogError(string EX)
        {
            string currentTime = "[" + DateTime.Now.ToString() + "]: ";
            string ePath = Application.StartupPath + @"\.cache\_errorLog.txt";
            File.AppendAllText(ePath, currentTime + EX + "\n\n");
        }
    }
}
