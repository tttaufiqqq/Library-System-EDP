namespace Library_Management_System_project
{
    partial class LoanDetailsDialog
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
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.labelBook = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelIssueDate = new System.Windows.Forms.Label();
            this.labelReturnDate = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelNote = new System.Windows.Forms.Label();
            this.buttonRequestReturn = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.SuspendLayout();
            //
            // pictureBoxCover
            //
            this.pictureBoxCover.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxCover.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(140, 220);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 0;
            this.pictureBoxCover.TabStop = false;
            //
            // labelBook
            //
            this.labelBook.AutoSize = false;
            this.labelBook.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBook.Location = new System.Drawing.Point(165, 12);
            this.labelBook.Name = "labelBook";
            this.labelBook.Size = new System.Drawing.Size(288, 45);
            this.labelBook.TabIndex = 1;
            //
            // labelAuthor
            //
            this.labelAuthor.AutoSize = false;
            this.labelAuthor.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(165, 60);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(288, 20);
            this.labelAuthor.TabIndex = 2;
            //
            // labelIssueDate
            //
            this.labelIssueDate.AutoSize = false;
            this.labelIssueDate.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIssueDate.Location = new System.Drawing.Point(165, 84);
            this.labelIssueDate.Name = "labelIssueDate";
            this.labelIssueDate.Size = new System.Drawing.Size(288, 20);
            this.labelIssueDate.TabIndex = 3;
            //
            // labelReturnDate
            //
            this.labelReturnDate.AutoSize = false;
            this.labelReturnDate.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReturnDate.Location = new System.Drawing.Point(165, 108);
            this.labelReturnDate.Name = "labelReturnDate";
            this.labelReturnDate.Size = new System.Drawing.Size(288, 20);
            this.labelReturnDate.TabIndex = 4;
            //
            // labelStatus
            //
            this.labelStatus.AutoSize = false;
            this.labelStatus.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(165, 132);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(288, 20);
            this.labelStatus.TabIndex = 5;
            //
            // labelNote
            //
            this.labelNote.AutoSize = false;
            this.labelNote.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote.ForeColor = System.Drawing.Color.DimGray;
            this.labelNote.Location = new System.Drawing.Point(165, 156);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(288, 40);
            this.labelNote.TabIndex = 6;
            //
            // buttonRequestReturn
            //
            this.buttonRequestReturn.Location = new System.Drawing.Point(165, 205);
            this.buttonRequestReturn.Name = "buttonRequestReturn";
            this.buttonRequestReturn.Size = new System.Drawing.Size(140, 34);
            this.buttonRequestReturn.TabIndex = 7;
            this.buttonRequestReturn.Text = "Request Return";
            this.buttonRequestReturn.UseVisualStyleBackColor = true;
            this.buttonRequestReturn.Click += new System.EventHandler(this.buttonRequestReturn_Click);
            //
            // buttonClose
            //
            this.buttonClose.Location = new System.Drawing.Point(313, 205);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(140, 34);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            //
            // LoanDetailsDialog
            //
            this.CancelButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 250);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonRequestReturn);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelReturnDate);
            this.Controls.Add(this.labelIssueDate);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelBook);
            this.Controls.Add(this.pictureBoxCover);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanDetailsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoanDetailsDialog";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Label labelBook;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelIssueDate;
        private System.Windows.Forms.Label labelReturnDate;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Button buttonRequestReturn;
        private System.Windows.Forms.Button buttonClose;
    }
}
