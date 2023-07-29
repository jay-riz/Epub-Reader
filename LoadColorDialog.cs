using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{

    public partial class LoadColorDialog : Form
    {
        public static bool mainWindoIsUsing = false;
        public static bool epubViewIsUsing = false;

        
        public LoadColorDialog()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }



        private void button1_Click(object sender, EventArgs e)
        {
           FontRawToHexColorDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BACKGROUND_FontRawToHexColorDialog();
        }

        //static string MultipleReplace(string text, Dictionary<string, string> replacements)
        //{
        //    return Regex.Replace(text,
        //                 "(" + String.Join("|", replacements.Keys) + ")",
        //                 delegate (Match m) { return replacements[m.Value]; });
        //}

        public string btnFontColor;
        public string btnBgColor;
        public string mainFontColor;
        public string mainBgColor;

        public void FontRawToHexColorDialog()
        {
            ColorDialog cDialog = new ColorDialog();
            ColorConverter conv = new ColorConverter();

            cDialog.Color = button1.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = cDialog.Color;
                btnFontColor = String.Format("#{0:X2}{1:X2}{2:X2}", cDialog.Color.R, cDialog.Color.G, cDialog.Color.B);
                mainFontColor = String.Format("#{0:X2}{1:X2}{2:X2}", cDialog.Color.R, cDialog.Color.G, cDialog.Color.B);

            }
        }

        public void BACKGROUND_FontRawToHexColorDialog()
        {
            ColorDialog cDialog = new ColorDialog();
            ColorConverter conv = new ColorConverter();

            cDialog.Color = button1.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = cDialog.Color;
                btnBgColor = String.Format("#{0:X2}{1:X2}{2:X2}", cDialog.Color.R, cDialog.Color.G, cDialog.Color.B);
                mainBgColor = String.Format("#{0:X2}{1:X2}{2:X2}", cDialog.Color.R, cDialog.Color.G, cDialog.Color.B);
            }
        }

        static public void LogError(string EX)
        {
            string currentTime = "[" + DateTime.Now.ToString() + "]: ";
            string ePath = Application.StartupPath + @"\.cache\_errorLog.txt";
            File.AppendAllText(ePath, currentTime + EX + "\n\n");
        }

        private void ForEpubViewColor()
        {
            Form2.PressRefresh = false;
            Form2.KIERLSEARCHFORCSS();

            try
            {
                for (int i = 0; i < Form2.CSSFOUNDList.Count; i++)
                {
                    File.AppendAllText(Form2.CSSFOUNDList[i], "body { background-color: " + btnBgColor + ";  } h1,h2,h3,h4, p { color: " + btnFontColor + "; }"); ;

                }

            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }

        }

        private void ForMainWindowColor()
        {
            //mainWindow.colorFontOfMainWindow = mainFontColor;
            //mainWindow.colorPanelofMainWindow = mainBgColor;

            File.WriteAllText(Application.StartupPath + @"/.cache/mainFont_color.txt", mainFontColor);
            File.WriteAllText(Application.StartupPath + @"/.cache/mainBackground_color.txt", mainBgColor);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (epubViewIsUsing == true)
            {
                ForEpubViewColor();
                MessageBox.Show("Changed Sucessfully", "Info");
                epubViewIsUsing = false;
            }
           
            if
                (mainWindoIsUsing == true){
                ForMainWindowColor();
                MessageBox.Show("Changed Sucessfully", "Info");
                mainWindoIsUsing = false;
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2.BoolReset = false;
        }

        private void LoadColorDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
