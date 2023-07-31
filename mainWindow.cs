using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using WindowsFormsApp3.OtherFuncs;

namespace WindowsFormsApp3
{

    public partial class mainWindow : Form
    {
       public static string colorPanelofMainWindow = "#045c73";
       public static string colorFontOfMainWindow = "#f68818";
       public string LIBRARY_PATH = Application.StartupPath + @"\Epub Library";
       public List<string> textOfPath = new List<string> ();
       public List<string> TocTocTocFolder = new List<string>();
        public mainWindow()
        {
            InitializeComponent();
        }
        public void CreateDir(string _crePath)
        {
            if (!Directory.Exists(_crePath))
            {
                Directory.CreateDirectory(_crePath);
            }

        }

        public void ErrorDialog(string text)
        {
        MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ExtractToZip(string zip, string extractDir)
        {
        System.IO.Compression.ZipFile.ExtractToDirectory(zip, extractDir);
        }


        public void EPUB_LOAD()
        {
            try //start
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "EPUB files (*.epub)|*.epub;";
                openFileDialog.ShowDialog();//This should be at the top of this thread.

                //string LIBRARY_PATH = Application.StartupPath + @"\Epub Library";

                string store_epubPath = openFileDialog.FileName; ;

                CreateDir(LIBRARY_PATH);

                string _onlyFileNameWithoutExt = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string _epubFolder = LIBRARY_PATH + @"\" + _onlyFileNameWithoutExt;             

                CreateDir(_epubFolder);

                string _epubDesPath = _epubFolder + @"\" + _onlyFileNameWithoutExt + @".epub";


                if (!File.Exists(_epubDesPath))
                {
                    File.Copy(store_epubPath, _epubDesPath);

                    string _extractedDir = _epubFolder + @"\epub_ext";

                    if (!Directory.Exists(_extractedDir))
                    {
                        ExtractToZip(_epubDesPath, _extractedDir);
                    }
                    SQLiteConnection sqlite_conn;
                    sqlite_conn = CreateConnection();

                    

                    InsertData(sqlite_conn, _onlyFileNameWithoutExt, _extractedDir);
                    Create_CoverTxt(_extractedDir);

                    string path_dbIsValid = Application.StartupPath + @"\.cache\_cov.txt";
                    var aza = File.ReadAllText(path_dbIsValid);
                    SearchForCover();

                    

                    File.Copy(textOfPath[0], aza + @"\Cover.jpg", true);
                   
                    textOfPath.Clear();
                }
                else
                {
                    ErrorDialog("File is already exist!"); return;
                };
            }
            catch (System.ArgumentException ex)
            {
                Logging.LogError(ex.ToString());
            } // end

        }
        static public SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(@"Data Source=Book_database.db; Version = 3;New=True;Compress=True;");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Logging.LogError(ex.ToString()) ;
            }
            return sqlite_conn;
        }

       private void CreateTable(SQLiteConnection conn)
        {
            try
            {
                SQLiteCommand sqlite_cmd;
                string createSqlQuery = "CREATE TABLE kierl_table(book_name VARCHAR(20), file_path VARCHAR(20));";
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = createSqlQuery;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                Logging.LogError(ex.ToString());
            }
           
        }

        private static void InsertData(SQLiteConnection conn, string xName, string xfilePath)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();


            sqlite_cmd.CommandText = @"INSERT INTO kierl_table(book_name, file_path) VALUES(@book_name, @file_path); ";

            sqlite_cmd.Parameters.AddWithValue("@book_name", xName);
            sqlite_cmd.Parameters.AddWithValue("@file_path", xfilePath);

            sqlite_cmd.ExecuteNonQuery();

        }

        public void ReadData(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM kierl_table";

            //sqlite_datareader = sqlite_cmd.ExecuteReader();
            //while (sqlite_datareader.Read())
            //{
            //    string myreader = sqlite_datareader.GetString(0);
            //    dataGridView1.Rows.Insert(0, sqlite_datareader.GetString(0), sqlite_datareader.GetString(1));
            //    dataGridView1.DataSource.

            //}
            DataTable dta = new DataTable();
            SQLiteDataAdapter dataadp = new SQLiteDataAdapter(sqlite_cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            dataGridView1.Columns[0].HeaderText = "Book's Name";
            dataGridView1.Columns[1].HeaderText = "FilePath";
            conn.Close();




        }

        public void Create_CoverTxt(string writehere)
        {
            string path_dbIsValid = Application.StartupPath + @"\.cache\_cov.txt";
            string dbDir = Application.StartupPath + @"\.cache";
            CreateDir(dbDir);

            File.WriteAllText(path_dbIsValid, writehere);

            
        }
        public void Create_DBtxt()
        {
            string path_dbIsValid = Application.StartupPath + @"\.cache\_db.txt";
            string dbDir = Application.StartupPath + @"\.cache";
            CreateDir(dbDir);
            if (!File.Exists(path_dbIsValid))
            {
                File.Create(path_dbIsValid).Dispose();
            }

        }


        
        private void Form1_Load(object sender, EventArgs e)
        {
           
            textBox1.Hide();
            textBox2.Hide();

            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();

            string path_dbIsValid = Application.StartupPath + @"\.cache\_db.txt";

            Create_DBtxt();

            string _db_parse = File.ReadAllText(path_dbIsValid);


            if (_db_parse == "" || _db_parse == "false")
            {
                File.WriteAllText(path_dbIsValid, "true");
            }
            try
            {
                CreateTable(sqlite_conn);
            }
            catch (Exception ex)
            {
                Logging.LogError(ex.ToString());
            }
            ReadData(sqlite_conn);

            // If directory does not exist, create it
            CreateDir(LIBRARY_PATH);
        }
        private void DeleteData(SQLiteConnection conn, string xName)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = @"DELETE FROM kierl_table WHERE book_name LIKE '" + xName + "'";
            sqlite_cmd.ExecuteNonQuery();

        }
        private void btnLibrary_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = LIBRARY_PATH,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", LIBRARY_PATH));
                Logging.LogError(ex.ToString());
            }
        }

        public static string btnRefLoadingTxt;
        private void buttonDesigns4_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            btnAddBook.Text = "Loading...";
            btnRefLoadingTxt = btnAddBook.Text;        
            EPUB_LOAD();
            
            btnAddBook.Text = "Add Book";
            btnRefLoadingTxt = btnAddBook.Text;
            ReadData(sqlite_conn);
            
           

        }

        public void SearchForCover()
        {
            string pointerPath = Application.StartupPath + @"\.cache\_cov.txt";
            string sourceDirectory = File.ReadAllText(pointerPath);
            //DirectoryInfo di = new DirectoryInfo(sourceDirectory);
            var OnlyHTML = Directory.EnumerateFiles(sourceDirectory, "*.jpg", SearchOption.AllDirectories);
           
            foreach (string c in OnlyHTML)
            {
                textOfPath.Add(c);
            }

        }
        public static string PZPZTOC;
        public void SELECTselectRow(DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView1.CurrentRow.Selected = true;
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["book_name"].FormattedValue.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["file_path"].FormattedValue.ToString();
                    var JPGpath = textBox2.Text;
                    pictureBox1.ImageLocation = JPGpath + @"\Cover.jpg";
                    PZPZTOC = textBox2.Text;
                    lblTitle.Text = textBox1.Text.Replace("_"," ");
                    lblCaptitle.Visible = true;

                }
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                Logging.LogError(ex.ToString());
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SELECTselectRow(e);
            

        }

        private void OPEN_BOOK_LOAD()
        {

            if (textBox1.Text != "" || textBox2.Text != "")
            {
                string dirPath = Application.StartupPath + @"\.cache";
                CreateDir(dirPath);
                File.WriteAllText(dirPath + @"\sys.txt", textBox2.Text);
                Form2 frm2 = new Form2();
                frm2.Show();
            }
            else
            {

            }
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OPEN_BOOK_LOAD();
            SELECTselectRow(e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SELECTselectRow(e);

        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OPEN_BOOK_LOAD();
          
          
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            DeleteData(sqlite_conn, textBox1.Text);
            ReadData(sqlite_conn);
            try
            {
                Directory.Delete(LIBRARY_PATH + @"\" + textBox1.Text, true);
            }
            catch (Exception ex)
            {
                Logging.LogError(ex.ToString());
            }
            textBox1.Clear();
            textBox2.Clear();


        }

        private void customizedButton1_Click(object sender, EventArgs e)
        {
            OPEN_BOOK_LOAD();
         
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SELECTselectRow(e);
        }

        private void buttonDesigns3_Click(object sender, EventArgs e)
        {

        }

        private void AllFontColors(string colorhex)
        {
            label2.ForeColor = ColorTranslator.FromHtml(colorhex);
            btnAddBook.ForeColor = ColorTranslator.FromHtml(colorhex);
            btnViewOpen.ForeColor = ColorTranslator.FromHtml(colorhex);
            btnLibrary.ForeColor = ColorTranslator.FromHtml(colorhex);
            btnColorTheme.ForeColor = ColorTranslator.FromHtml(colorhex);
            lblCaptitle.ForeColor = ColorTranslator.FromHtml(colorhex);
        }

        private void AllPanelColors(string panelhex)
        {
            rightPanel.BackColor = ColorTranslator.FromHtml(panelhex);
            leftPanel.BackColor = ColorTranslator.FromHtml(panelhex);
            btnAddBook.BackColor = ColorTranslator.FromHtml(panelhex);
            btnViewOpen.BackColor = ColorTranslator.FromHtml(panelhex);
            btnLibrary.BackColor = ColorTranslator.FromHtml(panelhex);
            btnColorTheme.BackColor = ColorTranslator.FromHtml(panelhex);
            lblCaptitle.BackColor = ColorTranslator.FromHtml(panelhex);
        }

        private void buttonDesigns3_Click_1(object sender, EventArgs e)
        {
            LoadColorDialog lcd = new LoadColorDialog();
            LoadColorDialog.mainWindoIsUsing = true;
            lcd.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AllFontColors(colorFontOfMainWindow);
            AllPanelColors(colorPanelofMainWindow);
        }

        private void leftPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        //--------------------------------------------------------------------------



    }
}
