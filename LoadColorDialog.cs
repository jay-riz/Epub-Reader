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

        public void FontRawToHexColorDialog()
        {
            ColorDialog cDialog = new ColorDialog();
            ColorConverter conv = new ColorConverter();

            cDialog.Color = button1.BackColor;
            if (cDialog.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = cDialog.Color;
                btnFontColor = String.Format("#{0:X2}{1:X2}{2:X2}", cDialog.Color.R, cDialog.Color.G, cDialog.Color.B);
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
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form2.KIERLSEARCHFORCSS();

           

            //var stringDic = new Dictionary<string, string>();
            //stringDic.Add("Color", " ");
            //stringDic.Add("[", " ");
            //stringDic.Add("]", " ");
            

            //string cf = MultipleReplace(colorFont, stringDic);
            //string bg = MultipleReplace(colorFont, stringDic);
            try
            {
                for (int i = 0; i < Form2.CSSFOUNDList.Count; i++)
                {
                    File.AppendAllText(Form2.CSSFOUNDList[i], "body { background-color: " + btnBgColor + ";  } h1,h2,h3,h4, p { color: " + btnFontColor + "; }"); ;

                }
            
                //File.WriteAllText(CSSFOUNDList[0], "h1,h2,h3,h4,p{ font-size: " + baseFontSize.ToString() + "px; font-weight: bold; }");
                //File.WriteAllText(CSSFOUNDList[1], "h1,h2,h3,h4,p{ font-size: " + baseFontSize.ToString() + "px; font-weight: bold; } ");
            }
            catch
            {
                ;
            }



            
           

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2.BoolReset = false;
        }
    }
}
