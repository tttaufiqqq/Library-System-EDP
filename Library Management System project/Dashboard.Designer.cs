namespace Library_Management_System_project
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panelUsers = new System.Windows.Forms.Panel();
            this.dashboard_Users = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelReturned = new System.Windows.Forms.Panel();
            this.dashboard_Returned = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelBorrowed = new System.Windows.Forms.Panel();
            this.dashboard_Issued = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelAvailable = new System.Windows.Forms.Panel();
            this.dashboard_Available = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chartsPanel = new System.Windows.Forms.Panel();
            this.chartBooksByStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartUsersByRole = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartIssuesOverTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTopBorrowed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelReturned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelBorrowed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.chartsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBooksByStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsersByRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIssuesOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopBorrowed)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUsers
            // 
            this.panelUsers.BackColor = System.Drawing.Color.SteelBlue;
            this.panelUsers.Controls.Add(this.dashboard_Users);
            this.panelUsers.Controls.Add(this.pictureBox4);
            this.panelUsers.Controls.Add(this.label3);
            this.panelUsers.Location = new System.Drawing.Point(3, 417);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(223, 132);
            this.panelUsers.TabIndex = 4;
            this.panelUsers.MouseEnter += new System.EventHandler(this.panelUsers_MouseEnter);
            this.panelUsers.MouseLeave += new System.EventHandler(this.panelUsers_MouseLeave);
            // 
            // dashboard_Users
            // 
            this.dashboard_Users.AutoSize = true;
            this.dashboard_Users.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_Users.ForeColor = System.Drawing.Color.White;
            this.dashboard_Users.Location = new System.Drawing.Point(168, 75);
            this.dashboard_Users.Name = "dashboard_Users";
            this.dashboard_Users.Size = new System.Drawing.Size(32, 40);
            this.dashboard_Users.TabIndex = 2;
            this.dashboard_Users.Text = "0";
            // 
            // pictureBox4
            // 
            this.pictureBox4.ErrorImage = null;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.InitialImage = null;
            this.pictureBox4.Location = new System.Drawing.Point(15, 55);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(60, 60);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(57, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Registered Users";
            // 
            // panelReturned
            // 
            this.panelReturned.BackColor = System.Drawing.Color.SteelBlue;
            this.panelReturned.Controls.Add(this.dashboard_Returned);
            this.panelReturned.Controls.Add(this.pictureBox3);
            this.panelReturned.Controls.Add(this.label6);
            this.panelReturned.Location = new System.Drawing.Point(3, 3);
            this.panelReturned.Name = "panelReturned";
            this.panelReturned.Size = new System.Drawing.Size(223, 132);
            this.panelReturned.TabIndex = 3;
            this.panelReturned.MouseEnter += new System.EventHandler(this.panelReturned_MouseEnter);
            this.panelReturned.MouseLeave += new System.EventHandler(this.panelReturned_MouseLeave);
            // 
            // dashboard_Returned
            // 
            this.dashboard_Returned.AutoSize = true;
            this.dashboard_Returned.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_Returned.ForeColor = System.Drawing.Color.White;
            this.dashboard_Returned.Location = new System.Drawing.Point(172, 75);
            this.dashboard_Returned.Name = "dashboard_Returned";
            this.dashboard_Returned.Size = new System.Drawing.Size(32, 40);
            this.dashboard_Returned.TabIndex = 2;
            this.dashboard_Returned.Text = "0";
            // 
            // pictureBox3
            // 
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(15, 55);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 60);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(68, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Returned Books";
            // 
            // panelBorrowed
            // 
            this.panelBorrowed.BackColor = System.Drawing.Color.SteelBlue;
            this.panelBorrowed.Controls.Add(this.dashboard_Issued);
            this.panelBorrowed.Controls.Add(this.pictureBox2);
            this.panelBorrowed.Controls.Add(this.label4);
            this.panelBorrowed.Location = new System.Drawing.Point(3, 279);
            this.panelBorrowed.Name = "panelBorrowed";
            this.panelBorrowed.Size = new System.Drawing.Size(223, 132);
            this.panelBorrowed.TabIndex = 3;
            this.panelBorrowed.MouseEnter += new System.EventHandler(this.panelBorrowed_MouseEnter);
            this.panelBorrowed.MouseLeave += new System.EventHandler(this.panelBorrowed_MouseLeave);
            // 
            // dashboard_Issued
            // 
            this.dashboard_Issued.AutoSize = true;
            this.dashboard_Issued.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_Issued.ForeColor = System.Drawing.Color.White;
            this.dashboard_Issued.Location = new System.Drawing.Point(168, 75);
            this.dashboard_Issued.Name = "dashboard_Issued";
            this.dashboard_Issued.Size = new System.Drawing.Size(32, 40);
            this.dashboard_Issued.TabIndex = 2;
            this.dashboard_Issued.Text = "0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(15, 55);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(69, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Borrowed Books";
            // 
            // panelAvailable
            // 
            this.panelAvailable.BackColor = System.Drawing.Color.SteelBlue;
            this.panelAvailable.Controls.Add(this.dashboard_Available);
            this.panelAvailable.Controls.Add(this.pictureBox1);
            this.panelAvailable.Controls.Add(this.label1);
            this.panelAvailable.Location = new System.Drawing.Point(3, 141);
            this.panelAvailable.Name = "panelAvailable";
            this.panelAvailable.Size = new System.Drawing.Size(223, 132);
            this.panelAvailable.TabIndex = 0;
            this.panelAvailable.MouseEnter += new System.EventHandler(this.panelAvailable_MouseEnter);
            this.panelAvailable.MouseLeave += new System.EventHandler(this.panelAvailable_MouseLeave);
            // 
            // dashboard_Available
            // 
            this.dashboard_Available.AutoSize = true;
            this.dashboard_Available.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_Available.ForeColor = System.Drawing.Color.White;
            this.dashboard_Available.Location = new System.Drawing.Point(161, 75);
            this.dashboard_Available.Name = "dashboard_Available";
            this.dashboard_Available.Size = new System.Drawing.Size(32, 40);
            this.dashboard_Available.TabIndex = 2;
            this.dashboard_Available.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(15, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Books";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelReturned);
            this.flowLayoutPanel1.Controls.Add(this.panelAvailable);
            this.flowLayoutPanel1.Controls.Add(this.panelBorrowed);
            this.flowLayoutPanel1.Controls.Add(this.panelUsers);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(640, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 565);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.dataGridView1);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.monthCalendar1);
            this.flowLayoutPanel2.Controls.Add(this.statusStrip1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 52);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(640, 513);
            this.flowLayoutPanel2.TabIndex = 6;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 29);
            this.label7.TabIndex = 4;
            this.label7.Text = "Registered Users\r\n";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(634, 189);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.MouseEnter += new System.EventHandler(this.dataGridView1_MouseEnter);
            this.dataGridView1.MouseLeave += new System.EventHandler(this.dataGridView1_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "Today\'s Date:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(9, 262);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 7;
            this.monthCalendar1.MouseEnter += new System.EventHandler(this.monthCalendar1_MouseEnter);
            this.monthCalendar1.MouseLeave += new System.EventHandler(this.monthCalendar1_MouseLeave);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(640, 26);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Azure;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.pictureBox5);
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(640, 46);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(3, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(40, 40);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(49, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dashboard";
            //
            // chartsPanel
            //
            this.chartsPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.chartsPanel.Controls.Add(this.chartBooksByStatus);
            this.chartsPanel.Controls.Add(this.chartUsersByRole);
            this.chartsPanel.Controls.Add(this.chartIssuesOverTime);
            this.chartsPanel.Controls.Add(this.chartTopBorrowed);
            this.chartsPanel.Location = new System.Drawing.Point(0, 52);
            this.chartsPanel.Name = "chartsPanel";
            this.chartsPanel.Size = new System.Drawing.Size(640, 513);
            this.chartsPanel.TabIndex = 9;
            this.chartsPanel.Visible = false;
            //
            // chartBooksByStatus
            //
            this.chartBooksByStatus.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Area1"));
            this.chartBooksByStatus.Location = new System.Drawing.Point(5, 5);
            this.chartBooksByStatus.Name = "chartBooksByStatus";
            this.chartBooksByStatus.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Series1")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            });
            this.chartBooksByStatus.Size = new System.Drawing.Size(310, 245);
            this.chartBooksByStatus.TabIndex = 0;
            this.chartBooksByStatus.Text = "Books by Status";
            this.chartBooksByStatus.Titles.Add("Books by Status");
            //
            // chartUsersByRole
            //
            this.chartUsersByRole.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Area1"));
            this.chartUsersByRole.Location = new System.Drawing.Point(325, 5);
            this.chartUsersByRole.Name = "chartUsersByRole";
            this.chartUsersByRole.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Series1")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
            });
            this.chartUsersByRole.Size = new System.Drawing.Size(310, 245);
            this.chartUsersByRole.TabIndex = 1;
            this.chartUsersByRole.Text = "Users by Role";
            this.chartUsersByRole.Titles.Add("Users by Role");
            //
            // chartIssuesOverTime
            //
            this.chartIssuesOverTime.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Area1"));
            this.chartIssuesOverTime.Location = new System.Drawing.Point(5, 260);
            this.chartIssuesOverTime.Name = "chartIssuesOverTime";
            this.chartIssuesOverTime.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Series1")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            });
            this.chartIssuesOverTime.Size = new System.Drawing.Size(310, 245);
            this.chartIssuesOverTime.TabIndex = 2;
            this.chartIssuesOverTime.Text = "Issues over Time";
            this.chartIssuesOverTime.Titles.Add("Issues over Time");
            //
            // chartTopBorrowed
            //
            this.chartTopBorrowed.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Area1"));
            this.chartTopBorrowed.Location = new System.Drawing.Point(325, 260);
            this.chartTopBorrowed.Name = "chartTopBorrowed";
            this.chartTopBorrowed.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Series1")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
            });
            this.chartTopBorrowed.Size = new System.Drawing.Size(310, 245);
            this.chartTopBorrowed.TabIndex = 3;
            this.chartTopBorrowed.Text = "Top Borrowed Books";
            this.chartTopBorrowed.Titles.Add("Top Borrowed Books");
            //
            // Dashboard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.chartsPanel);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(880, 565);
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelReturned.ResumeLayout(false);
            this.panelReturned.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelBorrowed.ResumeLayout(false);
            this.panelBorrowed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelAvailable.ResumeLayout(false);
            this.panelAvailable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBooksByStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsersByRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIssuesOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopBorrowed)).EndInit();
            this.chartsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelReturned;
        private System.Windows.Forms.Label dashboard_Returned;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelBorrowed;
        private System.Windows.Forms.Label dashboard_Issued;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelAvailable;
        private System.Windows.Forms.Label dashboard_Available;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label dashboard_Users;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel chartsPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBooksByStatus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUsersByRole;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIssuesOverTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopBorrowed;
    }
}
