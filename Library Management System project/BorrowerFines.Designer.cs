namespace Library_Management_System_project
{
    partial class BorrowerFines
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
            this.panelActions = new System.Windows.Forms.Panel();
            this.labelHint = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonPay = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            //
            // panelActions
            //
            this.panelActions.Controls.Add(this.labelHint);
            this.panelActions.Controls.Add(this.labelTotal);
            this.panelActions.Controls.Add(this.buttonPay);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 515);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(734, 50);
            this.panelActions.TabIndex = 1;
            //
            // labelHint
            //
            this.labelHint.AutoSize = false;
            this.labelHint.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHint.ForeColor = System.Drawing.Color.White;
            this.labelHint.Location = new System.Drawing.Point(190, 27);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(530, 18);
            this.labelHint.TabIndex = 2;
            this.labelHint.Text = "A fine becomes payable once the book has been returned.";
            //
            // labelTotal
            //
            this.labelTotal.AutoSize = false;
            this.labelTotal.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(190, 6);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(300, 20);
            this.labelTotal.TabIndex = 1;
            this.labelTotal.Text = "Total unpaid: RM 0.00";
            //
            // buttonPay
            //
            this.buttonPay.Enabled = false;
            this.buttonPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPay.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPay.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonPay.ForeColor = System.Drawing.Color.White;
            this.buttonPay.Location = new System.Drawing.Point(15, 8);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(160, 34);
            this.buttonPay.TabIndex = 0;
            this.buttonPay.Text = "PAY ONLINE (FPX)";
            this.buttonPay.UseVisualStyleBackColor = false;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            //
            // dataGridView1
            //
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(734, 515);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            //
            // BorrowerFines
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelActions);
            this.Name = "BorrowerFines";
            this.Size = new System.Drawing.Size(734, 565);
            this.panelActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
