using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp3.OtherFuncs
{
    public static class Global
    {
        public static string LIBRARY_PATH = Application.StartupPath + @"\Epub Library";
        static public void LogError(string EX)
        {
            string currentTime = "[" + DateTime.Now.ToString() + "]: ";
            string ePath = Application.StartupPath + @"\.cache\_errorLog.txt";
            File.AppendAllText(ePath, currentTime + EX + "\n\n");
        }

        static public string SourceDirectoryOfSysTxt()
        {
            string pointerPath = Application.StartupPath + @"\.cache\sys.txt";
            string sourceDirectory = File.ReadAllText(pointerPath);

            return sourceDirectory;
        }


    }


}
