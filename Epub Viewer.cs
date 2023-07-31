using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using WindowsFormsApp3.OtherFuncs;

namespace WindowsFormsApp3  
{

    public partial class Form2 : Form
    {

        List<string> NCX_FILEPATH = new List<string>();
        List<string> TOSUBSTRING_SUBTEXT_PATH = new List<string>();
        public static List<string> CSSFOUNDList = new List<string>();

        List<string> ParseListBox = new List<string>();



        public Form2()
        {
            InitializeComponent();
        }


        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(@"Data Source=Book_database.db; Version = 3;New=True;Compress=True;");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch
            {
                  ;
            }
            return sqlite_conn;
        }

        private void DeleteData(SQLiteConnection conn, string xName)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = @"DELETE FROM kierl_table WHERE book_name LIKE '@file_path' ; ";
            sqlite_cmd.Parameters.AddWithValue("@book_name", xName);
            var a = sqlite_cmd.Parameters.AddWithValue("@book_name", xName).ToString();
            Console.WriteLine(a);
            sqlite_cmd.ExecuteNonQuery();

        }

        private void SearchForToc()
        {
            try
            {
                
                var _SearchTocNcs = Directory.EnumerateFiles(Global.SourceDirectoryOfSysTxt(), "*.ncx", SearchOption.AllDirectories);

                foreach (string Toc in _SearchTocNcs)
                {
                    NCX_FILEPATH.Add(Toc);
                }

                foreach (string addToSubtext in NCX_FILEPATH)
                {
                    TOSUBSTRING_SUBTEXT_PATH.Add(addToSubtext);
                }
                //MessageBox.Show(TOSUBSTRING_SUBTEXT_PATH[0]); //NCX SINGLE PATH

            }
            catch
            {
                  ;
            }



        }

        public static bool boolWebBrowserRefresh = false;

        public static void KIERLSEARCHFORCSS()
        {

            var _PERFILECSS = Directory.EnumerateFiles(Global.SourceDirectoryOfSysTxt(), "*.css", SearchOption.AllDirectories);

            foreach (string css in _PERFILECSS)
            {
                CSSFOUNDList.Add(css);

            }

        }

       
        private void WbRefresh()
        {
            if (boolWebBrowserRefresh == false)
            {
                webBrowser1.Refresh();
                boolWebBrowserRefresh = true;
            }

           



        }



        private void ReadAllXhtml_html()
        {

            //DirectoryInfo di = new DirectoryInfo(sourceDirectory);
            List<string> tableOfXHTMLContents = new List<string>();
            List<string> tableOfHTMLOnly = new List<string>();

            //Start
            try
            {
                //FileInfo fi = di.GetFiles()[0];
                //var firstFile = fi.ToString();
                //MessageBox.Show(firstFile); //To return a first file that could possibly found.
                //                            //END
            }
            catch
            {
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConnection();
                DeleteData(sqlite_conn, Global.SourceDirectoryOfSysTxt());
                
            }

            try
            {

                var XhtmlFiles = Directory.EnumerateFiles(Global.SourceDirectoryOfSysTxt(), "*.xhtml", SearchOption.AllDirectories);
                var OnlyHTML = Directory.EnumerateFiles(Global.SourceDirectoryOfSysTxt(), "*.html", SearchOption.AllDirectories);

                foreach (string currentFile in XhtmlFiles)
                {
                    //files.Add(currentFile); //string array or List<string>
                    tableOfXHTMLContents.Add(currentFile);

                }
                foreach (string currentH in OnlyHTML)
                {
                    //files.Add(currentFile); //string array or List<string>
                    tableOfHTMLOnly.Add(currentH);

                }

                if (tableOfXHTMLContents.Count() < 3)
                {
                    foreach (string eachPath in OnlyHTML)
                    {
                        listBox1.Items.Add(eachPath);
                    }
                }
                else
                {
                    //MessageBox.Show(tableOfXHTMLContents.Count().ToString());
                    foreach (string eachPath in tableOfXHTMLContents)
                    {
                        listBox1.Items.Add(eachPath);
                    }

                }

            }
            catch
            {
                  ;
            }

            try
            {
                string firstPath = Application.StartupPath + @"\.cache\styles.css";

                string percss = CSSFOUNDList[0];

                File.Copy(firstPath, percss, true);
            }
            catch 
            {
                  ;
            }

        }

        private static List<string> ExtractFromBody(string body, string start, string end)
        {
            List<string> matched = new List<string>();

            int indexStart = 0;
            int indexEnd = 0;

            bool exit = false;
            while (!exit)
            {
                indexStart = body.IndexOf(start);

                if (indexStart != -1)
                {
                    indexEnd = indexStart + body.Substring(indexStart).IndexOf(end);

                    matched.Add(body.Substring(indexStart + start.Length, indexEnd - indexStart - start.Length));

                    body = body.Substring(indexEnd + end.Length);
                }
                else
                {
                    exit = true;
                }
            }

            return matched;
        }

        public void DeleteThisSpecificStrings()
        {
            for (int n = listBox1.Items.Count - 1; n >= 0; --n)
            {
                string removelistitem = "Cover";
                if (listBox1.Items[n].ToString().Contains(removelistitem))
                {
                    listBox1.Items.RemoveAt(n);
                }

                try
                {
                    string removeTwo = "toc.ncx";
                    if (listBox1.Items[n].ToString().Contains(removeTwo))
                    {
                        listBox1.Items.RemoveAt(n);
                    }

                    string removeThree = "TOC";

                    if (listBox1.Items[n].ToString().Contains(removeThree))
                    {
                        listBox1.Items.RemoveAt(n);
                    }

                }
                catch (System.ArgumentOutOfRangeException)
                {
                      ;
                }
                

               

            }



        }

        private void ExecuteRegex(string _path, string start, string end, ListBox listboxID)
        {

            string body = File.ReadAllText(_path);

            //string body = "super exemple of string key : text I want to keep - end of my stringsuper exemple of string key : text I want to keep - end of my stringsuper exemple of string ke";
            //string start = "<text>";
            //string end = "</text>";

            List<string> regexStringList = new List<string>();


            regexStringList = ExtractFromBody(body, start, end);

            foreach (string item in regexStringList)
            {
                listboxID.Items.Add(item);
            }

            DeleteThisSpecificStrings();


        }



        List<string> message2 = new List<string>();
       

        private void Form2_Load(object sender, EventArgs e)
        {
        
            btnNext.Text = "Start";
            webBrowser1.Visible = false;
            //KIERLSEARCHFORCSS();        
            ReadAllXhtml_html();
            Mercury();


            SearchForToc();
           
            try
            {
                for (int i = 0; i < TOSUBSTRING_SUBTEXT_PATH.Count; i++)
                {
                    ExecuteRegex(TOSUBSTRING_SUBTEXT_PATH[i], "<text>", "</text>", listBox2);
                }
                
            }
            catch
            {
                  ;
            }
            

            listBox1.SelectedIndex = listBox1.SelectedIndex = 0;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private string ListBox1_TEXT()
        {
            string text = listBox1.SelectedItem.ToString();
            return text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int max = listBox1.Items.Count;
            if (listBox1.SelectedIndex.ToString().Contains("-"))
            {
                listBox1.SelectedIndex++;
                btnPrev.Enabled = false;
            }
            else if (listBox1.SelectedIndex >= max)
            {
                btnNext.Enabled = false;
            }
            else
            {
                //button3.Enabled = true;
                btnNext.Enabled = true;
                webBrowser1.Navigate(ListBox1_TEXT());
            }

        }

        private const int _ZOOM = 63;
        private const int _DONTPROMPTUSER = 2;

        private void ZoomInOut(int num)
        {
            dynamic obj = webBrowser1.ActiveXInstance;

            obj.ExecWB(_ZOOM, _DONTPROMPTUSER, num, IntPtr.Zero);
        }

        
        double baseFontSize = 16;
        private void button1_Click(object sender, EventArgs e)
        {
            KIERLSEARCHFORCSS();
            baseFontSize += 1.2;
            IncreaseOrDecreaseFontSize();


            webBrowser1.Refresh();
        }

        private void IncreaseOrDecreaseFontSize ()
        {
            try
            {
                for (int i = 0; i < CSSFOUNDList.Count; i++)
                {
                    File.AppendAllText(CSSFOUNDList[i], "h1,h2,h3,h4,p{ font-size: " + baseFontSize.ToString() + "px;  }");
                }
                //File.WriteAllText(CSSFOUNDList[0], "h1,h2,h3,h4,p{ font-size: " + baseFontSize.ToString() + "px; font-weight: bold; }");
                //File.WriteAllText(CSSFOUNDList[1], "h1,h2,h3,h4,p{ font-size: " + baseFontSize.ToString() + "px; font-weight: bold; } ");
            }
            catch
            {
                ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KIERLSEARCHFORCSS();
            baseFontSize -= 1.2;
            IncreaseOrDecreaseFontSize();

            webBrowser1.Refresh();
        }
        public void CopyCSStoPath(string INDEXPATH)
        {
            string firstPath = Application.StartupPath + @"\.cache\styles.css";
            if (!File.Exists(firstPath))
            {
                File.Copy(firstPath, INDEXPATH);
            }
        }

        void OnScroll(object sender, EventArgs e)
        {
            var script =
            @"(function()
            {
               var e = document.documentElement;
               if (e.scrollHeight - e.scrollTop === e.clientHeight)
                   return true;
               else
                   return false;
               var f = document.documentElement;
               if (e.scrollHeight - e.scrollBottom === e.clientHeight)
                   return true;
               else
                   return false;
                   


            })();"

;
            var result = webBrowser1.Document.InvokeScript("eval", new object[] { script });
            if ((bool)result)
            {
                try
                {
                    listBox1.SelectedIndex++;
                }
                catch
                {
                      ;
                }
            }


        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           
            
            this.webBrowser1.Document.Window.AttachEventHandler("onscroll", OnScroll);

        }
        private void button3_Click(object sender, EventArgs e)
        {

            int max = listBox1.Items.Count;
            if (listBox3.SelectedIndex.ToString().Contains("-"))
            {
                btnPrev.Enabled = false;
                listBox3.SelectedIndex--;
            }
            else if (listBox3.SelectedIndex >= max)
            {
                btnNext.Enabled = false;
            }
            else
            {
                //button3.Enabled = true;
                btnNext.Enabled = true;
                listBox3.SelectedIndex--;
            }

        }


        void Mercury()
        {
            try
            {
                //MessageBox.Show(mainWindow.PZPZTOC);
                mainWindow mw = new mainWindow();
                var count = listBox1.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    var sss = listBox1.Items[i].ToString();
                    List<string> lll = new List<string>();

                    lll = ExtractFromBody(sss, mainWindow.PZPZTOC, ".xhtml");
                    foreach (string l in lll)
                    {
                        listBox3.Items.Add(l);
                        //ParseListBox.Add(l);

                    }

                }
            }
            catch(System.ArgumentOutOfRangeException)
            {
                //MessageBox.Show(mainWindow.PZPZTOC);
                mainWindow mw = new mainWindow();
                var count = listBox1.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    var sss = listBox1.Items[i].ToString();
                    List<string> lll = new List<string>();

                    lll = ExtractFromBody(sss, mainWindow.PZPZTOC, ".html");
                    foreach (string l in lll)
                    {
                        listBox3.Items.Add(l);
                        //ParseListBox.Add(l);

                    }

                }
            }
          
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnNext.Text = "Next";
            if (btnIncFontSize.Focused)
            {
                btnPrev.Focus();
            }

            webBrowser1.Visible = true;
            listBox2.Visible = false;
            int max = listBox1.Items.Count;
            if (listBox3.SelectedIndex.ToString().Contains("-"))
            {
                btnPrev.Enabled = false;
                listBox3.SelectedIndex++;
            }
            else if (listBox3.SelectedIndex >= max)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
                btnNext.Enabled = true;
                try
                {
                    listBox3.SelectedIndex++;
                }
                catch (ArgumentOutOfRangeException)
                {
                    btnNext.Enabled = false;
                }
            }
            

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            CSSFOUNDList.Clear();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == 0) {
                btnPrev.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
                btnNext.Text = "Next";
            }
           
            try
            {
                webBrowser1.Visible = true;
                listBox2.Visible = false;
                listBox1.SelectedIndex = listBox3.SelectedIndex;
            }
            catch (System.ArgumentOutOfRangeException)
            {

                mainWindow mw = new mainWindow();
                mw.ErrorDialog("Can't Parse File");
                listBox3.SelectedIndex--;

            }
           
        }

        private void listBox3_MouseClick(object sender, MouseEventArgs e)
        {
            btnPrev.Enabled = true;
        }

        private void btnSepia_Click(object sender, EventArgs e)
        {
            KIERLSEARCHFORCSS();
            ChangeColor(@"214, 202, 178");

        }

        public void ChangeColor (string color)
        {
            try
            {
                for (int i = 0; i < CSSFOUNDList.Count; i++)
                {
                    File.AppendAllText(CSSFOUNDList[i], "body { background-color: rgb(" + color + ");  }");
                   
                }
                webBrowser1.Refresh();
                //File.WriteAllText(CSSFOUNDList[0], "h1,h2,h3,h4,p{ font-size: " + baseFontSize.ToString() + "px; font-weight: bold; }");
                //File.WriteAllText(CSSFOUNDList[1], "h1,h2,h3,h4,p{ font-size: " + baseFontSize.ToString() + "px; font-weight: bold; } ");
            }
            catch
            {
                ;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            KIERLSEARCHFORCSS();
            ChangeColor("91, 91, 91");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btnInvisible.PerformClick();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadColorDialog lcd = new LoadColorDialog();
            LoadColorDialog.epubViewIsUsing = true;
            lcd.Show();
        }

        public static bool BoolReset = false;

        public static bool PressRefresh = false;
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            WbRefresh();

            if (BoolReset == false)
            {
                btnInvisible.PerformClick();
                BoolReset = true;
            }

            if (PressRefresh == false)
            {
                btnRefresh.PerformClick();
                PressRefresh = true;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < CSSFOUNDList.Count; i++)
                {
                    File.WriteAllText(CSSFOUNDList[i], "{DELETED}");

                }
                webBrowser1.Refresh();
                //File.WriteAllText(CSSFOUNDList[0], "h1,h2,h3,h4,p{ font-size: " + baseFontSize.ToString() + "px; font-weight: bold; }");
                //File.WriteAllText(CSSFOUNDList[1], "h1,h2,h3,h4,p{ font-size: " + baseFontSize.ToString() + "px; font-weight: bold; } ");
            }
            catch
            {
                ;
            }


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
            
        }
    }

}
