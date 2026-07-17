namespace Library_Management_System_project
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonManageUsers = new System.Windows.Forms.Button();
            this.manageUsers1 = new Library_Management_System_project.ManageUsers();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            //
            // buttonManageUsers
            //
            this.buttonManageUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonManageUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManageUsers.ForeColor = System.Drawing.Color.White;
            this.buttonManageUsers.Location = new System.Drawing.Point(24, 417);
            this.buttonManageUsers.Name = "buttonManageUsers";
            this.buttonManageUsers.Size = new System.Drawing.Size(165, 32);
            this.buttonManageUsers.TabIndex = 7;
            this.buttonManageUsers.Text = "MANAGE USERS";
            this.buttonManageUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonManageUsers.UseVisualStyleBackColor = true;
            this.buttonManageUsers.Click += new System.EventHandler(this.buttonManageUsers_Click);
            this.panel2.Controls.Add(this.buttonManageUsers);
            //
            // manageUsers1
            //
            this.manageUsers1.BackColor = System.Drawing.Color.SteelBlue;
            this.manageUsers1.Location = new System.Drawing.Point(0, 0);
            this.manageUsers1.Name = "manageUsers1";
            this.manageUsers1.Size = new System.Drawing.Size(880, 565);
            this.manageUsers1.TabIndex = 5;
            this.panel3.Controls.Add(this.manageUsers1);
            //
            // AdminMainForm
            //
            this.Name = "AdminMainForm";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonManageUsers;
        private ManageUsers manageUsers1;
    }
}
