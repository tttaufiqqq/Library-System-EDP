namespace Library_Management_System_project
{
    partial class FineDetailsDialog
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
            this.labelBook = new System.Windows.Forms.Label();
            this.labelBorrower = new System.Windows.Forms.Label();
            this.labelOverdue = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelAssessedDate = new System.Windows.Forms.Label();
            this.labelPaidDate = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // labelBook
            //
            this.labelBook.AutoSize = false;
            this.labelBook.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBook.Location = new System.Drawing.Point(20, 15);
            this.labelBook.Name = "labelBook";
            this.labelBook.Size = new System.Drawing.Size(340, 30);
            this.labelBook.TabIndex = 0;
            //
            // labelBorrower
            //
            this.labelBorrower.AutoSize = false;
            this.labelBorrower.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBorrower.Location = new System.Drawing.Point(20, 55);
            this.labelBorrower.Name = "labelBorrower";
            this.labelBorrower.Size = new System.Drawing.Size(340, 22);
            this.labelBorrower.TabIndex = 1;
            //
            // labelOverdue
            //
            this.labelOverdue.AutoSize = false;
            this.labelOverdue.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOverdue.Location = new System.Drawing.Point(20, 85);
            this.labelOverdue.Name = "labelOverdue";
            this.labelOverdue.Size = new System.Drawing.Size(340, 22);
            this.labelOverdue.TabIndex = 2;
            //
            // labelAmount
            //
            this.labelAmount.AutoSize = false;
            this.labelAmount.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmount.Location = new System.Drawing.Point(20, 115);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(340, 22);
            this.labelAmount.TabIndex = 3;
            //
            // labelStatus
            //
            this.labelStatus.AutoSize = false;
            this.labelStatus.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(20, 145);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(340, 22);
            this.labelStatus.TabIndex = 4;
            //
            // labelAssessedDate
            //
            this.labelAssessedDate.AutoSize = false;
            this.labelAssessedDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssessedDate.ForeColor = System.Drawing.Color.DimGray;
            this.labelAssessedDate.Location = new System.Drawing.Point(20, 178);
            this.labelAssessedDate.Name = "labelAssessedDate";
            this.labelAssessedDate.Size = new System.Drawing.Size(340, 20);
            this.labelAssessedDate.TabIndex = 5;
            //
            // labelPaidDate
            //
            this.labelPaidDate.AutoSize = false;
            this.labelPaidDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaidDate.ForeColor = System.Drawing.Color.DimGray;
            this.labelPaidDate.Location = new System.Drawing.Point(20, 200);
            this.labelPaidDate.Name = "labelPaidDate";
            this.labelPaidDate.Size = new System.Drawing.Size(340, 20);
            this.labelPaidDate.TabIndex = 6;
            //
            // buttonClose
            //
            this.buttonClose.Location = new System.Drawing.Point(270, 232);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 34);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            //
            // FineDetailsDialog
            //
            this.CancelButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 280);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelPaidDate);
            this.Controls.Add(this.labelAssessedDate);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelOverdue);
            this.Controls.Add(this.labelBorrower);
            this.Controls.Add(this.labelBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FineDetailsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FineDetailsDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelBook;
        private System.Windows.Forms.Label labelBorrower;
        private System.Windows.Forms.Label labelOverdue;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelAssessedDate;
        private System.Windows.Forms.Label labelPaidDate;
        private System.Windows.Forms.Button buttonClose;
    }
}
