namespace Library_Management_System_project
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonFine = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.buttonReturnBooks = new System.Windows.Forms.Button();
            this.buttonIssueBooks = new System.Windows.Forms.Button();
            this.buttonAddBooks = new System.Windows.Forms.Button();
            this.buttonDashboard = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fine1 = new Library_Management_System_project.Fine();
            this.dashboard1 = new Library_Management_System_project.Dashboard();
            this.addBooks1 = new Library_Management_System_project.AddBooks();
            this.issuedBooks1 = new Library_Management_System_project.IssuedBooks();
            this.returnBooks1 = new Library_Management_System_project.ReturnBooks();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelUser = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 29);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Library Management System | Main Form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(802, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            this.toolTip1.SetToolTip(this.label1, "Click this to close the form");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonFine);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.buttonLogOut);
            this.panel2.Controls.Add(this.buttonReturnBooks);
            this.panel2.Controls.Add(this.buttonIssueBooks);
            this.panel2.Controls.Add(this.buttonAddBooks);
            this.panel2.Controls.Add(this.buttonDashboard);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 459);
            this.panel2.TabIndex = 1;
            // 
            // buttonFine
            // 
            this.buttonFine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonFine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonFine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFine.ForeColor = System.Drawing.Color.White;
            this.buttonFine.Image = ((System.Drawing.Image)(resources.GetObject("buttonFine.Image")));
            this.buttonFine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFine.Location = new System.Drawing.Point(18, 306);
            this.buttonFine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFine.Name = "buttonFine";
            this.buttonFine.Size = new System.Drawing.Size(124, 26);
            this.buttonFine.TabIndex = 5;
            this.buttonFine.Text = "PAYMENT";
            this.buttonFine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.buttonFine, "Fine borrowers who return the books late");
            this.buttonFine.UseVisualStyleBackColor = true;
            this.buttonFine.Click += new System.EventHandler(this.buttonFine_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 404);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "LOG OUT";
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonLogOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOut.ForeColor = System.Drawing.Color.White;
            this.buttonLogOut.Image = ((System.Drawing.Image)(resources.GetObject("buttonLogOut.Image")));
            this.buttonLogOut.Location = new System.Drawing.Point(6, 394);
            this.buttonLogOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(34, 37);
            this.buttonLogOut.TabIndex = 2;
            this.toolTip1.SetToolTip(this.buttonLogOut, "Log out of the system");
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // buttonReturnBooks
            // 
            this.buttonReturnBooks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonReturnBooks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonReturnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReturnBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturnBooks.ForeColor = System.Drawing.Color.White;
            this.buttonReturnBooks.Image = ((System.Drawing.Image)(resources.GetObject("buttonReturnBooks.Image")));
            this.buttonReturnBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReturnBooks.Location = new System.Drawing.Point(18, 271);
            this.buttonReturnBooks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReturnBooks.Name = "buttonReturnBooks";
            this.buttonReturnBooks.Size = new System.Drawing.Size(124, 29);
            this.buttonReturnBooks.TabIndex = 2;
            this.buttonReturnBooks.Text = "RETURN BOOKS";
            this.buttonReturnBooks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.buttonReturnBooks, "Mark the issued books as returned");
            this.buttonReturnBooks.UseVisualStyleBackColor = true;
            this.buttonReturnBooks.Click += new System.EventHandler(this.buttonReturnBooks_Click);
            // 
            // buttonIssueBooks
            // 
            this.buttonIssueBooks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonIssueBooks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonIssueBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIssueBooks.ForeColor = System.Drawing.Color.White;
            this.buttonIssueBooks.Image = ((System.Drawing.Image)(resources.GetObject("buttonIssueBooks.Image")));
            this.buttonIssueBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIssueBooks.Location = new System.Drawing.Point(18, 238);
            this.buttonIssueBooks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonIssueBooks.Name = "buttonIssueBooks";
            this.buttonIssueBooks.Size = new System.Drawing.Size(124, 28);
            this.buttonIssueBooks.TabIndex = 2;
            this.buttonIssueBooks.Text = "ISSUE BOOKS";
            this.buttonIssueBooks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.buttonIssueBooks, "Issues a book on borrowers\r\n");
            this.buttonIssueBooks.UseVisualStyleBackColor = true;
            this.buttonIssueBooks.Click += new System.EventHandler(this.buttonIssueBooks_Click);
            // 
            // buttonAddBooks
            // 
            this.buttonAddBooks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonAddBooks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonAddBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddBooks.ForeColor = System.Drawing.Color.White;
            this.buttonAddBooks.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddBooks.Image")));
            this.buttonAddBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddBooks.Location = new System.Drawing.Point(18, 206);
            this.buttonAddBooks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddBooks.Name = "buttonAddBooks";
            this.buttonAddBooks.Size = new System.Drawing.Size(124, 27);
            this.buttonAddBooks.TabIndex = 2;
            this.buttonAddBooks.Text = "ADD BOOKS";
            this.buttonAddBooks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.buttonAddBooks, "Add new books to the system");
            this.buttonAddBooks.UseVisualStyleBackColor = true;
            this.buttonAddBooks.Click += new System.EventHandler(this.buttonAddBooks_Click);
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboard.ForeColor = System.Drawing.Color.White;
            this.buttonDashboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonDashboard.Image")));
            this.buttonDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDashboard.Location = new System.Drawing.Point(18, 174);
            this.buttonDashboard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Size = new System.Drawing.Size(124, 28);
            this.buttonDashboard.TabIndex = 2;
            this.buttonDashboard.Text = "DASHBOARD";
            this.buttonDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.buttonDashboard, "See the statistic of the system");
            this.buttonDashboard.UseVisualStyleBackColor = true;
            this.buttonDashboard.Click += new System.EventHandler(this.buttonDashboard_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Welcome,";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(42, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.fine1);
            this.panel3.Controls.Add(this.dashboard1);
            this.panel3.Controls.Add(this.addBooks1);
            this.panel3.Controls.Add(this.issuedBooks1);
            this.panel3.Controls.Add(this.returnBooks1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(166, 29);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(659, 459);
            this.panel3.TabIndex = 2;
            // 
            // fine1
            // 
            this.fine1.BackColor = System.Drawing.Color.SteelBlue;
            this.fine1.Location = new System.Drawing.Point(0, 1);
            this.fine1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fine1.Name = "fine1";
            this.fine1.Size = new System.Drawing.Size(660, 456);
            this.fine1.TabIndex = 4;
            this.fine1.Load += new System.EventHandler(this.fine1_Load);
            // 
            // dashboard1
            // 
            this.dashboard1.BackColor = System.Drawing.Color.SteelBlue;
            this.dashboard1.Location = new System.Drawing.Point(0, -2);
            this.dashboard1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(660, 461);
            this.dashboard1.TabIndex = 3;
            // 
            // addBooks1
            // 
            this.addBooks1.BackColor = System.Drawing.Color.SteelBlue;
            this.addBooks1.Location = new System.Drawing.Point(0, 0);
            this.addBooks1.Margin = new System.Windows.Forms.Padding(2);
            this.addBooks1.Name = "addBooks1";
            this.addBooks1.Size = new System.Drawing.Size(660, 459);
            this.addBooks1.TabIndex = 2;
            // 
            // issuedBooks1
            // 
            this.issuedBooks1.BackColor = System.Drawing.Color.SteelBlue;
            this.issuedBooks1.Location = new System.Drawing.Point(0, -9);
            this.issuedBooks1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.issuedBooks1.Name = "issuedBooks1";
            this.issuedBooks1.Size = new System.Drawing.Size(660, 468);
            this.issuedBooks1.TabIndex = 1;
            // 
            // returnBooks1
            // 
            this.returnBooks1.BackColor = System.Drawing.Color.SteelBlue;
            this.returnBooks1.Location = new System.Drawing.Point(0, 0);
            this.returnBooks1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.returnBooks1.Name = "returnBooks1";
            this.returnBooks1.Size = new System.Drawing.Size(660, 459);
            this.returnBooks1.TabIndex = 0;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.BackColor = System.Drawing.Color.SteelBlue;
            this.labelUser.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.ForeColor = System.Drawing.Color.White;
            this.labelUser.Location = new System.Drawing.Point(80, 158);
            this.labelUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(69, 20);
            this.labelUser.TabIndex = 6;
            this.labelUser.Text = "username";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 488);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System - Staff";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAddBooks;
        private System.Windows.Forms.Button buttonDashboard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonReturnBooks;
        private System.Windows.Forms.Button buttonIssueBooks;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Panel panel3;
        private ReturnBooks returnBooks1;
        private Dashboard dashboard1;
        private AddBooks addBooks1;
        private IssuedBooks issuedBooks1;
        private System.Windows.Forms.Button buttonFine;
     
        private Fine fine1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelUser;
    }
}