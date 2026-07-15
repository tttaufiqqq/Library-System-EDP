namespace Library_Management_System_project
{
    partial class IssuedBooks
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bookIssue_author = new System.Windows.Forms.ComboBox();
            this.bookIssue_bookTitle = new System.Windows.Forms.ComboBox();
            this.bookIssue_status = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bookIssue_picturbox = new System.Windows.Forms.PictureBox();
            this.bookIssue_Clear = new System.Windows.Forms.Button();
            this.bookIssue_Delete = new System.Windows.Forms.Button();
            this.bookIssue_Update = new System.Windows.Forms.Button();
            this.bookIssue_Add = new System.Windows.Forms.Button();
            this.bookIssue_returnDate = new System.Windows.Forms.DateTimePicker();
            this.bookIssue_issueDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bookIssue_email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bookIssue_contact = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bookIssue_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bookIssue_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookIssue_picturbox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.bookIssue_author);
            this.panel1.Controls.Add(this.bookIssue_bookTitle);
            this.panel1.Controls.Add(this.bookIssue_status);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.bookIssue_picturbox);
            this.panel1.Controls.Add(this.bookIssue_Clear);
            this.panel1.Controls.Add(this.bookIssue_Delete);
            this.panel1.Controls.Add(this.bookIssue_Update);
            this.panel1.Controls.Add(this.bookIssue_Add);
            this.panel1.Controls.Add(this.bookIssue_returnDate);
            this.panel1.Controls.Add(this.bookIssue_issueDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.bookIssue_email);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.bookIssue_contact);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.bookIssue_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.bookIssue_id);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(25, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 216);
            this.panel1.TabIndex = 0;
            // 
            // bookIssue_author
            // 
            this.bookIssue_author.FormattingEnabled = true;
            this.bookIssue_author.Location = new System.Drawing.Point(355, 44);
            this.bookIssue_author.Name = "bookIssue_author";
            this.bookIssue_author.Size = new System.Drawing.Size(203, 24);
            this.bookIssue_author.TabIndex = 25;
            // 
            // bookIssue_bookTitle
            // 
            this.bookIssue_bookTitle.FormattingEnabled = true;
            this.bookIssue_bookTitle.Items.AddRange(new object[] {
            ""});
            this.bookIssue_bookTitle.Location = new System.Drawing.Point(355, 6);
            this.bookIssue_bookTitle.Name = "bookIssue_bookTitle";
            this.bookIssue_bookTitle.Size = new System.Drawing.Size(203, 24);
            this.bookIssue_bookTitle.TabIndex = 24;
            this.bookIssue_bookTitle.SelectedIndexChanged += new System.EventHandler(this.bookIssue_bookTitle_SelectedIndexChanged);
            // 
            // bookIssue_status
            // 
            this.bookIssue_status.FormattingEnabled = true;
            this.bookIssue_status.Items.AddRange(new object[] {
            "Returned",
            "Not Returned"});
            this.bookIssue_status.Location = new System.Drawing.Point(635, 12);
            this.bookIssue_status.Name = "bookIssue_status";
            this.bookIssue_status.Size = new System.Drawing.Size(178, 24);
            this.bookIssue_status.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(564, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Status:";
            // 
            // bookIssue_picturbox
            // 
            this.bookIssue_picturbox.Location = new System.Drawing.Point(688, 55);
            this.bookIssue_picturbox.Name = "bookIssue_picturbox";
            this.bookIssue_picturbox.Size = new System.Drawing.Size(100, 100);
            this.bookIssue_picturbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bookIssue_picturbox.TabIndex = 21;
            this.bookIssue_picturbox.TabStop = false;
            // 
            // bookIssue_Clear
            // 
            this.bookIssue_Clear.BackColor = System.Drawing.Color.SteelBlue;
            this.bookIssue_Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookIssue_Clear.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookIssue_Clear.ForeColor = System.Drawing.Color.White;
            this.bookIssue_Clear.Location = new System.Drawing.Point(540, 165);
            this.bookIssue_Clear.Name = "bookIssue_Clear";
            this.bookIssue_Clear.Size = new System.Drawing.Size(88, 41);
            this.bookIssue_Clear.TabIndex = 20;
            this.bookIssue_Clear.Text = "Clear";
            this.bookIssue_Clear.UseVisualStyleBackColor = false;
            this.bookIssue_Clear.Click += new System.EventHandler(this.bookIssue_Clear_Click);
            // 
            // bookIssue_Delete
            // 
            this.bookIssue_Delete.BackColor = System.Drawing.Color.SteelBlue;
            this.bookIssue_Delete.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookIssue_Delete.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookIssue_Delete.ForeColor = System.Drawing.Color.White;
            this.bookIssue_Delete.Location = new System.Drawing.Point(430, 165);
            this.bookIssue_Delete.Name = "bookIssue_Delete";
            this.bookIssue_Delete.Size = new System.Drawing.Size(88, 41);
            this.bookIssue_Delete.TabIndex = 19;
            this.bookIssue_Delete.Text = "Delete";
            this.bookIssue_Delete.UseVisualStyleBackColor = false;
            this.bookIssue_Delete.Click += new System.EventHandler(this.bookIssue_Delete_Click);
            // 
            // bookIssue_Update
            // 
            this.bookIssue_Update.BackColor = System.Drawing.Color.SteelBlue;
            this.bookIssue_Update.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookIssue_Update.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookIssue_Update.ForeColor = System.Drawing.Color.White;
            this.bookIssue_Update.Location = new System.Drawing.Point(320, 166);
            this.bookIssue_Update.Name = "bookIssue_Update";
            this.bookIssue_Update.Size = new System.Drawing.Size(88, 41);
            this.bookIssue_Update.TabIndex = 18;
            this.bookIssue_Update.Text = "Update";
            this.bookIssue_Update.UseVisualStyleBackColor = false;
            this.bookIssue_Update.Click += new System.EventHandler(this.bookIssue_Update_Click);
            // 
            // bookIssue_Add
            // 
            this.bookIssue_Add.BackColor = System.Drawing.Color.SteelBlue;
            this.bookIssue_Add.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.bookIssue_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookIssue_Add.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookIssue_Add.ForeColor = System.Drawing.Color.White;
            this.bookIssue_Add.Location = new System.Drawing.Point(208, 166);
            this.bookIssue_Add.Name = "bookIssue_Add";
            this.bookIssue_Add.Size = new System.Drawing.Size(88, 41);
            this.bookIssue_Add.TabIndex = 17;
            this.bookIssue_Add.Text = "Add";
            this.bookIssue_Add.UseVisualStyleBackColor = false;
            this.bookIssue_Add.Click += new System.EventHandler(this.bookIssue_Add_Click);
            // 
            // bookIssue_returnDate
            // 
            this.bookIssue_returnDate.Location = new System.Drawing.Point(358, 133);
            this.bookIssue_returnDate.Name = "bookIssue_returnDate";
            this.bookIssue_returnDate.Size = new System.Drawing.Size(200, 22);
            this.bookIssue_returnDate.TabIndex = 16;
            // 
            // bookIssue_issueDate
            // 
            this.bookIssue_issueDate.Location = new System.Drawing.Point(358, 90);
            this.bookIssue_issueDate.Name = "bookIssue_issueDate";
            this.bookIssue_issueDate.Size = new System.Drawing.Size(200, 22);
            this.bookIssue_issueDate.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(253, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Return Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(253, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Borrow Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(253, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Author:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(253, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Book Title:";
            // 
            // bookIssue_email
            // 
            this.bookIssue_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bookIssue_email.Location = new System.Drawing.Point(83, 132);
            this.bookIssue_email.Name = "bookIssue_email";
            this.bookIssue_email.Size = new System.Drawing.Size(149, 22);
            this.bookIssue_email.TabIndex = 7;
            this.bookIssue_email.MouseEnter += new System.EventHandler(this.bookIssue_email_MouseEnter);
            this.bookIssue_email.MouseLeave += new System.EventHandler(this.bookIssue_email_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Email:";
            // 
            // bookIssue_contact
            // 
            this.bookIssue_contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bookIssue_contact.Location = new System.Drawing.Point(83, 88);
            this.bookIssue_contact.Name = "bookIssue_contact";
            this.bookIssue_contact.Size = new System.Drawing.Size(149, 22);
            this.bookIssue_contact.TabIndex = 5;
            this.bookIssue_contact.MouseEnter += new System.EventHandler(this.bookIssue_contact_MouseEnter);
            this.bookIssue_contact.MouseLeave += new System.EventHandler(this.bookIssue_contact_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Contact:";
            // 
            // bookIssue_name
            // 
            this.bookIssue_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bookIssue_name.Location = new System.Drawing.Point(83, 44);
            this.bookIssue_name.Name = "bookIssue_name";
            this.bookIssue_name.Size = new System.Drawing.Size(149, 22);
            this.bookIssue_name.TabIndex = 3;
            this.bookIssue_name.MouseEnter += new System.EventHandler(this.bookIssue_name_MouseEnter);
            this.bookIssue_name.MouseLeave += new System.EventHandler(this.bookIssue_name_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name:";
            // 
            // bookIssue_id
            // 
            this.bookIssue_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bookIssue_id.Location = new System.Drawing.Point(83, 6);
            this.bookIssue_id.Name = "bookIssue_id";
            this.bookIssue_id.Size = new System.Drawing.Size(149, 22);
            this.bookIssue_id.TabIndex = 1;
            this.bookIssue_id.MouseEnter += new System.EventHandler(this.bookIssue_id_MouseEnter);
            this.bookIssue_id.MouseLeave += new System.EventHandler(this.bookIssue_id_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Issue ID:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(25, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 319);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "All Borrowed Books";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.LightSkyBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridView1.Location = new System.Drawing.Point(14, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Navy;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(799, 262);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
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
            // IssuedBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "IssuedBooks";
            this.Size = new System.Drawing.Size(880, 565);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookIssue_picturbox)).EndInit();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker bookIssue_returnDate;
        private System.Windows.Forms.DateTimePicker bookIssue_issueDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox bookIssue_email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox bookIssue_contact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bookIssue_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bookIssue_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox bookIssue_picturbox;
        private System.Windows.Forms.Button bookIssue_Clear;
        private System.Windows.Forms.Button bookIssue_Delete;
        private System.Windows.Forms.Button bookIssue_Update;
        private System.Windows.Forms.Button bookIssue_Add;
        private System.Windows.Forms.ComboBox bookIssue_status;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox bookIssue_author;
        private System.Windows.Forms.ComboBox bookIssue_bookTitle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
