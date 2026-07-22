namespace Library_Management_System_project
{
    partial class Fine
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.labelTotalOutstanding = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewFines = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFines)).BeginInit();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.Controls.Add(this.buttonCalculate);
            this.panelHeader.Controls.Add(this.labelTotalOutstanding);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(849, 60);
            this.panelHeader.TabIndex = 0;
            //
            // buttonCalculate
            //
            this.buttonCalculate.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonCalculate.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCalculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCalculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalculate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalculate.ForeColor = System.Drawing.Color.White;
            this.buttonCalculate.Location = new System.Drawing.Point(725, 15);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(100, 30);
            this.buttonCalculate.TabIndex = 2;
            this.buttonCalculate.Text = "Refresh";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            //
            // labelTotalOutstanding
            //
            this.labelTotalOutstanding.AutoSize = true;
            this.labelTotalOutstanding.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalOutstanding.Location = new System.Drawing.Point(260, 21);
            this.labelTotalOutstanding.Name = "labelTotalOutstanding";
            this.labelTotalOutstanding.Size = new System.Drawing.Size(200, 17);
            this.labelTotalOutstanding.TabIndex = 1;
            this.labelTotalOutstanding.Text = "Total outstanding: RM 0.00";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fines Report";
            //
            // dataGridViewFines
            //
            this.dataGridViewFines.AllowUserToAddRows = false;
            this.dataGridViewFines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFines.Location = new System.Drawing.Point(0, 60);
            this.dataGridViewFines.Name = "dataGridViewFines";
            this.dataGridViewFines.ReadOnly = true;
            this.dataGridViewFines.RowHeadersWidth = 51;
            this.dataGridViewFines.RowTemplate.Height = 24;
            this.dataGridViewFines.Size = new System.Drawing.Size(849, 476);
            this.dataGridViewFines.TabIndex = 1;
            //
            // Fine
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.dataGridViewFines);
            this.Controls.Add(this.panelHeader);
            this.Name = "Fine";
            this.Size = new System.Drawing.Size(849, 536);
            this.Load += new System.EventHandler(this.fine_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label labelTotalOutstanding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewFines;
    }
}
