namespace Library_Management_System_project
{
    partial class RegisterForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.register_showpassword = new System.Windows.Forms.CheckBox();
            this.register_btn = new System.Windows.Forms.Button();
            this.register_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.register_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.register_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 33);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(419, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.toolTip1.SetToolTip(this.label1, "Click here to close the form");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // register_showpassword
            // 
            this.register_showpassword.AutoSize = true;
            this.register_showpassword.Location = new System.Drawing.Point(298, 473);
            this.register_showpassword.Name = "register_showpassword";
            this.register_showpassword.Size = new System.Drawing.Size(125, 20);
            this.register_showpassword.TabIndex = 21;
            this.register_showpassword.Text = "Show Password";
            this.toolTip1.SetToolTip(this.register_showpassword, "Click here to show your password");
            this.register_showpassword.UseVisualStyleBackColor = true;
            this.register_showpassword.CheckedChanged += new System.EventHandler(this.register_showpassword_CheckedChanged);
            // 
            // register_btn
            // 
            this.register_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.register_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.register_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.register_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.register_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.register_btn.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.register_btn.Location = new System.Drawing.Point(22, 512);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(412, 67);
            this.register_btn.TabIndex = 18;
            this.register_btn.Text = "REGISTER";
            this.register_btn.UseVisualStyleBackColor = false;
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // register_username
            // 
            this.register_username.Location = new System.Drawing.Point(104, 356);
            this.register_username.Name = "register_username";
            this.register_username.Size = new System.Drawing.Size(239, 22);
            this.register_username.TabIndex = 17;
            this.toolTip1.SetToolTip(this.register_username, "Enter your preferred username");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 16;
            this.label4.Text = "Username :";
            // 
            // register_email
            // 
            this.register_email.Location = new System.Drawing.Point(104, 265);
            this.register_email.Name = "register_email";
            this.register_email.Size = new System.Drawing.Size(239, 22);
            this.register_email.TabIndex = 15;
            this.toolTip1.SetToolTip(this.register_email, "Enter your email address");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 22);
            this.label3.TabIndex = 14;
            this.label3.Text = "Email Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 27);
            this.label2.TabIndex = 13;
            this.label2.Text = "Registration Form";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Management_System_project.Properties.Resources.library;
            this.pictureBox1.Location = new System.Drawing.Point(168, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // register_password
            // 
            this.register_password.Location = new System.Drawing.Point(104, 445);
            this.register_password.Name = "register_password";
            this.register_password.PasswordChar = '*';
            this.register_password.Size = new System.Drawing.Size(239, 22);
            this.register_password.TabIndex = 25;
            this.toolTip1.SetToolTip(this.register_password, "Enter your choice of password");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 22);
            this.label5.TabIndex = 24;
            this.label5.Text = "Password :";
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.backBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.backBtn.Location = new System.Drawing.Point(89, 623);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(268, 39);
            this.backBtn.TabIndex = 26;
            this.backBtn.Text = "BACK";
            this.toolTip1.SetToolTip(this.backBtn, "Already registered?\r\nClick here\r\n");
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 674);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.register_password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.register_showpassword);
            this.Controls.Add(this.register_btn);
            this.Controls.Add(this.register_username);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.register_email);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System - Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox register_showpassword;
        private System.Windows.Forms.Button register_btn;
        private System.Windows.Forms.TextBox register_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox register_email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox register_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}