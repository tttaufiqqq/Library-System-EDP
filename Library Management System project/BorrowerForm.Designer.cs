namespace Library_Management_System_project
{
    partial class BorrowerForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonMyLoans = new System.Windows.Forms.Button();
            this.buttonBrowseCatalog = new System.Windows.Forms.Button();
            this.buttonMyFines = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.borrowerCatalog1 = new Library_Management_System_project.BorrowerCatalog();
            this.borrowerFines1 = new Library_Management_System_project.BorrowerFines();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 35);
            this.panel1.TabIndex = 0;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Library Management System | Borrower";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(869, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 22);
            this.label1.TabIndex = 0;
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
            this.panel2.Controls.Add(this.labelWelcome);
            this.panel2.Controls.Add(this.buttonMyLoans);
            this.panel2.Controls.Add(this.buttonBrowseCatalog);
            this.panel2.Controls.Add(this.buttonMyFines);
            this.panel2.Controls.Add(this.buttonLogOut);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 565);
            this.panel2.TabIndex = 1;
            //
            // labelWelcome
            //
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.ForeColor = System.Drawing.Color.White;
            this.labelWelcome.Location = new System.Drawing.Point(15, 20);
            this.labelWelcome.MaximumSize = new System.Drawing.Size(140, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(120, 40);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome, !";
            //
            // buttonMyLoans
            //
            this.buttonMyLoans.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonMyLoans.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonMyLoans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMyLoans.ForeColor = System.Drawing.Color.White;
            this.buttonMyLoans.Location = new System.Drawing.Point(18, 174);
            this.buttonMyLoans.Name = "buttonMyLoans";
            this.buttonMyLoans.Size = new System.Drawing.Size(124, 28);
            this.buttonMyLoans.TabIndex = 1;
            this.buttonMyLoans.Text = "MY LOANS";
            this.toolTip1.SetToolTip(this.buttonMyLoans, "View your borrowed books");
            this.buttonMyLoans.UseVisualStyleBackColor = true;
            this.buttonMyLoans.Click += new System.EventHandler(this.buttonMyLoans_Click);
            //
            // buttonBrowseCatalog
            //
            this.buttonBrowseCatalog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonBrowseCatalog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonBrowseCatalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseCatalog.ForeColor = System.Drawing.Color.White;
            this.buttonBrowseCatalog.Location = new System.Drawing.Point(18, 206);
            this.buttonBrowseCatalog.Name = "buttonBrowseCatalog";
            this.buttonBrowseCatalog.Size = new System.Drawing.Size(124, 28);
            this.buttonBrowseCatalog.TabIndex = 2;
            this.buttonBrowseCatalog.Text = "BROWSE CATALOG";
            this.buttonBrowseCatalog.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTip1.SetToolTip(this.buttonBrowseCatalog, "Search the book catalog");
            this.buttonBrowseCatalog.UseVisualStyleBackColor = true;
            this.buttonBrowseCatalog.Click += new System.EventHandler(this.buttonBrowseCatalog_Click);
            //
            // buttonMyFines
            //
            this.buttonMyFines.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonMyFines.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonMyFines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMyFines.ForeColor = System.Drawing.Color.White;
            this.buttonMyFines.Location = new System.Drawing.Point(18, 238);
            this.buttonMyFines.Name = "buttonMyFines";
            this.buttonMyFines.Size = new System.Drawing.Size(124, 28);
            this.buttonMyFines.TabIndex = 3;
            this.buttonMyFines.Text = "MY FINES";
            this.toolTip1.SetToolTip(this.buttonMyFines, "View and pay your fines");
            this.buttonMyFines.UseVisualStyleBackColor = true;
            this.buttonMyFines.Click += new System.EventHandler(this.buttonMyFines_Click);
            //
            // buttonLogOut
            //
            this.buttonLogOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOut.ForeColor = System.Drawing.Color.White;
            this.buttonLogOut.Location = new System.Drawing.Point(18, 270);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(124, 28);
            this.buttonLogOut.TabIndex = 4;
            this.buttonLogOut.Text = "LOG OUT";
            this.toolTip1.SetToolTip(this.buttonLogOut, "Log out of the system");
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            //
            // panel3
            //
            this.panel3.Controls.Add(this.borrowerFines1);
            this.panel3.Controls.Add(this.borrowerCatalog1);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(166, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 565);
            this.panel3.TabIndex = 2;
            //
            // dataGridView1
            //
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(734, 565);
            this.dataGridView1.TabIndex = 0;
            //
            // borrowerCatalog1
            //
            this.borrowerCatalog1.BackColor = System.Drawing.Color.SteelBlue;
            this.borrowerCatalog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borrowerCatalog1.Location = new System.Drawing.Point(0, 0);
            this.borrowerCatalog1.Name = "borrowerCatalog1";
            this.borrowerCatalog1.Size = new System.Drawing.Size(734, 565);
            this.borrowerCatalog1.TabIndex = 1;
            this.borrowerCatalog1.Visible = false;
            //
            // borrowerFines1
            //
            this.borrowerFines1.BackColor = System.Drawing.Color.SteelBlue;
            this.borrowerFines1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borrowerFines1.Location = new System.Drawing.Point(0, 0);
            this.borrowerFines1.Name = "borrowerFines1";
            this.borrowerFines1.Size = new System.Drawing.Size(734, 565);
            this.borrowerFines1.TabIndex = 2;
            this.borrowerFines1.Visible = false;
            //
            // toolTip1
            //
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            //
            // BorrowerForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BorrowerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System - Borrower";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonMyLoans;
        private System.Windows.Forms.Button buttonBrowseCatalog;
        private System.Windows.Forms.Button buttonMyFines;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BorrowerCatalog borrowerCatalog1;
        private BorrowerFines borrowerFines1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
