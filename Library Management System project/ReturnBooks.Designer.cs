namespace Library_Management_System_project
{
    partial class ReturnBooks
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.changefont = new System.Windows.Forms.Button();
            this.return_dateIssued = new System.Windows.Forms.DateTimePicker();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.return_author = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.return_bookTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.return_pictureBox = new System.Windows.Forms.PictureBox();
            this.return_email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.return_contact = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.return_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.return_IssueID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.return_pictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.changefont);
            this.panel1.Controls.Add(this.return_dateIssued);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.buttonReturn);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.return_author);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.return_bookTitle);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.return_pictureBox);
            this.panel1.Controls.Add(this.return_email);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.return_contact);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.return_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.return_IssueID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(19, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 525);
            this.panel1.TabIndex = 0;
            // 
            // changefont
            // 
            this.changefont.BackColor = System.Drawing.Color.SteelBlue;
            this.changefont.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.changefont.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.changefont.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.changefont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changefont.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changefont.ForeColor = System.Drawing.Color.White;
            this.changefont.Location = new System.Drawing.Point(45, 486);
            this.changefont.Name = "changefont";
            this.changefont.Size = new System.Drawing.Size(209, 34);
            this.changefont.TabIndex = 21;
            this.changefont.Text = "Change Font";
            this.changefont.UseVisualStyleBackColor = false;
            this.changefont.Click += new System.EventHandler(this.changefont_Click);
            // 
            // return_dateIssued
            // 
            this.return_dateIssued.Location = new System.Drawing.Point(123, 409);
            this.return_dateIssued.Name = "return_dateIssued";
            this.return_dateIssued.Size = new System.Drawing.Size(171, 22);
            this.return_dateIssued.TabIndex = 20;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonClear.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(154, 447);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(100, 34);
            this.buttonClear.TabIndex = 17;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonReturn.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonReturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonReturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReturn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturn.ForeColor = System.Drawing.Color.White;
            this.buttonReturn.Location = new System.Drawing.Point(45, 447);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(100, 34);
            this.buttonReturn.TabIndex = 16;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = false;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 412);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Date Issued:";
            // 
            // return_author
            // 
            this.return_author.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.return_author.Location = new System.Drawing.Point(123, 362);
            this.return_author.Name = "return_author";
            this.return_author.Size = new System.Drawing.Size(171, 27);
            this.return_author.TabIndex = 13;
            this.return_author.MouseEnter += new System.EventHandler(this.return_author_MouseEnter);
            this.return_author.MouseLeave += new System.EventHandler(this.return_author_MouseLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Author:";
            // 
            // return_bookTitle
            // 
            this.return_bookTitle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.return_bookTitle.Location = new System.Drawing.Point(123, 316);
            this.return_bookTitle.Name = "return_bookTitle";
            this.return_bookTitle.Size = new System.Drawing.Size(171, 27);
            this.return_bookTitle.TabIndex = 11;
            this.return_bookTitle.MouseEnter += new System.EventHandler(this.return_bookTitle_MouseEnter);
            this.return_bookTitle.MouseLeave += new System.EventHandler(this.return_bookTitle_MouseLeave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Book Title:";
            // 
            // return_pictureBox
            // 
            this.return_pictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.return_pictureBox.Location = new System.Drawing.Point(99, 14);
            this.return_pictureBox.Name = "return_pictureBox";
            this.return_pictureBox.Size = new System.Drawing.Size(100, 100);
            this.return_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.return_pictureBox.TabIndex = 9;
            this.return_pictureBox.TabStop = false;
            // 
            // return_email
            // 
            this.return_email.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.return_email.Location = new System.Drawing.Point(123, 267);
            this.return_email.Name = "return_email";
            this.return_email.Size = new System.Drawing.Size(171, 27);
            this.return_email.TabIndex = 8;
            this.return_email.MouseEnter += new System.EventHandler(this.return_email_MouseEnter);
            this.return_email.MouseLeave += new System.EventHandler(this.return_email_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Email:";
            // 
            // return_contact
            // 
            this.return_contact.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.return_contact.Location = new System.Drawing.Point(123, 218);
            this.return_contact.Name = "return_contact";
            this.return_contact.Size = new System.Drawing.Size(171, 27);
            this.return_contact.TabIndex = 6;
            this.return_contact.MouseEnter += new System.EventHandler(this.return_contact_MouseEnter);
            this.return_contact.MouseLeave += new System.EventHandler(this.return_contact_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Contact:";
            // 
            // return_name
            // 
            this.return_name.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.return_name.Location = new System.Drawing.Point(123, 175);
            this.return_name.Name = "return_name";
            this.return_name.Size = new System.Drawing.Size(171, 27);
            this.return_name.TabIndex = 4;
            this.return_name.MouseEnter += new System.EventHandler(this.return_name_MouseEnter);
            this.return_name.MouseLeave += new System.EventHandler(this.return_name_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name:";
            // 
            // return_IssueID
            // 
            this.return_IssueID.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.return_IssueID.Location = new System.Drawing.Point(123, 127);
            this.return_IssueID.Name = "return_IssueID";
            this.return_IssueID.Size = new System.Drawing.Size(171, 27);
            this.return_IssueID.TabIndex = 2;
            this.return_IssueID.MouseEnter += new System.EventHandler(this.return_IssueID_MouseEnter);
            this.return_IssueID.MouseLeave += new System.EventHandler(this.return_IssueID_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Issue ID:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(345, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 525);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(469, 466);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Borrowed Books";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(880, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Azure;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // ReturnBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ReturnBooks";
            this.Size = new System.Drawing.Size(880, 565);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.return_pictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox return_IssueID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox return_author;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox return_bookTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox return_pictureBox;
        private System.Windows.Forms.TextBox return_email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox return_contact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox return_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker return_dateIssued;
        private System.Windows.Forms.Button changefont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
