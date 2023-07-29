namespace WindowsFormsApp3
{
    partial class mainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnViewOpen = new WindowsFormsApp3.customizedButton();
            this.btnAddBook = new WindowsFormsApp3.customizedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnColorTheme = new WindowsFormsApp3.customizedButton();
            this.btnLibrary = new WindowsFormsApp3.customizedButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCaptitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(91)))), ((int)(((byte)(118)))));
            this.leftPanel.Controls.Add(this.label3);
            this.leftPanel.Controls.Add(this.label2);
            this.leftPanel.Controls.Add(this.pictureBox2);
            this.leftPanel.Controls.Add(this.btnViewOpen);
            this.leftPanel.Controls.Add(this.btnAddBook);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Controls.Add(this.btnColorTheme);
            this.leftPanel.Controls.Add(this.btnLibrary);
            this.leftPanel.Controls.Add(this.textBox2);
            this.leftPanel.Controls.Add(this.textBox1);
            this.leftPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.leftPanel.Location = new System.Drawing.Point(-2, 1);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(212, 477);
            this.leftPanel.TabIndex = 0;
            this.leftPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.leftPanel_Paint);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 2);
            this.label3.TabIndex = 13;
            this.label3.Text = "----------------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(48, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Epub Reader";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApp3.Properties.Resources.book_img;
            this.pictureBox2.Location = new System.Drawing.Point(14, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // btnViewOpen
            // 
            this.btnViewOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(91)))), ((int)(((byte)(118)))));
            this.btnViewOpen.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(91)))), ((int)(((byte)(118)))));
            this.btnViewOpen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.btnViewOpen.BorderRadius = 10;
            this.btnViewOpen.BorderSize = 1;
            this.btnViewOpen.FlatAppearance.BorderSize = 0;
            this.btnViewOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewOpen.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnViewOpen.Location = new System.Drawing.Point(9, 106);
            this.btnViewOpen.Name = "btnViewOpen";
            this.btnViewOpen.Size = new System.Drawing.Size(190, 37);
            this.btnViewOpen.TabIndex = 11;
            this.btnViewOpen.Text = "View / Open";
            this.btnViewOpen.TextColor = System.Drawing.Color.DarkOrange;
            this.btnViewOpen.UseVisualStyleBackColor = false;
            this.btnViewOpen.Click += new System.EventHandler(this.customizedButton1_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(91)))), ((int)(((byte)(118)))));
            this.btnAddBook.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(91)))), ((int)(((byte)(118)))));
            this.btnAddBook.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.btnAddBook.BorderRadius = 10;
            this.btnAddBook.BorderSize = 1;
            this.btnAddBook.FlatAppearance.BorderSize = 0;
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnAddBook.Location = new System.Drawing.Point(9, 63);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(190, 37);
            this.btnAddBook.TabIndex = 7;
            this.btnAddBook.Text = "Add Book.";
            this.btnAddBook.TextColor = System.Drawing.Color.DarkOrange;
            this.toolTip1.SetToolTip(this.btnAddBook, "Add your EPUB files.");
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.buttonDesigns4_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(1, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 2);
            this.label1.TabIndex = 4;
            this.label1.Text = "----------------------";
            // 
            // btnColorTheme
            // 
            this.btnColorTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(91)))), ((int)(((byte)(118)))));
            this.btnColorTheme.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(91)))), ((int)(((byte)(118)))));
            this.btnColorTheme.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.btnColorTheme.BorderRadius = 10;
            this.btnColorTheme.BorderSize = 1;
            this.btnColorTheme.FlatAppearance.BorderSize = 0;
            this.btnColorTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorTheme.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnColorTheme.Location = new System.Drawing.Point(9, 231);
            this.btnColorTheme.Name = "btnColorTheme";
            this.btnColorTheme.Size = new System.Drawing.Size(190, 37);
            this.btnColorTheme.TabIndex = 3;
            this.btnColorTheme.Text = "Change Color Theme";
            this.btnColorTheme.TextColor = System.Drawing.Color.DarkOrange;
            this.btnColorTheme.UseVisualStyleBackColor = false;
            this.btnColorTheme.Click += new System.EventHandler(this.buttonDesigns3_Click_1);
            // 
            // btnLibrary
            // 
            this.btnLibrary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(91)))), ((int)(((byte)(118)))));
            this.btnLibrary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(91)))), ((int)(((byte)(118)))));
            this.btnLibrary.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.btnLibrary.BorderRadius = 10;
            this.btnLibrary.BorderSize = 1;
            this.btnLibrary.FlatAppearance.BorderSize = 0;
            this.btnLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibrary.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnLibrary.Location = new System.Drawing.Point(9, 188);
            this.btnLibrary.Name = "btnLibrary";
            this.btnLibrary.Size = new System.Drawing.Size(190, 37);
            this.btnLibrary.TabIndex = 2;
            this.btnLibrary.Text = "Library Folder";
            this.btnLibrary.TextColor = System.Drawing.Color.DarkOrange;
            this.toolTip1.SetToolTip(this.btnLibrary, "Directory path of your library (epub files)");
            this.btnLibrary.UseVisualStyleBackColor = false;
            this.btnLibrary.Click += new System.EventHandler(this.btnLibrary_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(107, 372);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(83, 20);
            this.textBox2.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 372);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 8;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewBookToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 70);
            // 
            // viewBookToolStripMenuItem
            // 
            this.viewBookToolStripMenuItem.Name = "viewBookToolStripMenuItem";
            this.viewBookToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.viewBookToolStripMenuItem.Text = "View Book";
            this.viewBookToolStripMenuItem.Click += new System.EventHandler(this.viewBookToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(591, 477);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(91)))), ((int)(((byte)(118)))));
            this.panel2.Controls.Add(this.rightPanel);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(203, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 477);
            this.panel2.TabIndex = 2;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.lblTitle);
            this.rightPanel.Controls.Add(this.lblCaptitle);
            this.rightPanel.Controls.Add(this.pictureBox1);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(585, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(246, 477);
            this.rightPanel.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitle.Location = new System.Drawing.Point(66, 295);
            this.lblTitle.MaximumSize = new System.Drawing.Size(152, 39);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(152, 39);
            this.lblTitle.TabIndex = 2;
            // 
            // lblCaptitle
            // 
            this.lblCaptitle.AutoSize = true;
            this.lblCaptitle.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCaptitle.Location = new System.Drawing.Point(12, 293);
            this.lblCaptitle.Name = "lblCaptitle";
            this.lblCaptitle.Size = new System.Drawing.Size(48, 21);
            this.lblCaptitle.TabIndex = 1;
            this.lblCaptitle.Text = "Title:";
            this.lblCaptitle.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(222, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 478);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.leftPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Epub Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private customizedButton btnColorTheme;
        private customizedButton btnLibrary;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private customizedButton btnAddBook;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private customizedButton btnViewOpen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblCaptitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
    }
}

