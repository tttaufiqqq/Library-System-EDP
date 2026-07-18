namespace Library_Management_System_project
{
    partial class RequestDetailsDialog
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
            this.labelBorrower = new System.Windows.Forms.Label();
            this.labelContact = new System.Windows.Forms.Label();
            this.labelRequestedDate = new System.Windows.Forms.Label();
            this.labelReturnDate = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonApprove = new System.Windows.Forms.Button();
            this.buttonReject = new System.Windows.Forms.Button();
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
            // labelBorrower
            //
            this.labelBorrower.AutoSize = false;
            this.labelBorrower.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBorrower.Location = new System.Drawing.Point(165, 84);
            this.labelBorrower.Name = "labelBorrower";
            this.labelBorrower.Size = new System.Drawing.Size(288, 20);
            this.labelBorrower.TabIndex = 3;
            //
            // labelContact
            //
            this.labelContact.AutoSize = false;
            this.labelContact.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContact.Location = new System.Drawing.Point(165, 108);
            this.labelContact.Name = "labelContact";
            this.labelContact.Size = new System.Drawing.Size(288, 20);
            this.labelContact.TabIndex = 4;
            //
            // labelRequestedDate
            //
            this.labelRequestedDate.AutoSize = false;
            this.labelRequestedDate.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRequestedDate.Location = new System.Drawing.Point(165, 132);
            this.labelRequestedDate.Name = "labelRequestedDate";
            this.labelRequestedDate.Size = new System.Drawing.Size(288, 20);
            this.labelRequestedDate.TabIndex = 5;
            //
            // labelReturnDate
            //
            this.labelReturnDate.AutoSize = false;
            this.labelReturnDate.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReturnDate.Location = new System.Drawing.Point(165, 156);
            this.labelReturnDate.Name = "labelReturnDate";
            this.labelReturnDate.Size = new System.Drawing.Size(288, 20);
            this.labelReturnDate.TabIndex = 6;
            //
            // labelStatus
            //
            this.labelStatus.AutoSize = false;
            this.labelStatus.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(165, 180);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(288, 20);
            this.labelStatus.TabIndex = 7;
            //
            // buttonApprove
            //
            this.buttonApprove.Location = new System.Drawing.Point(165, 210);
            this.buttonApprove.Name = "buttonApprove";
            this.buttonApprove.Size = new System.Drawing.Size(90, 34);
            this.buttonApprove.TabIndex = 8;
            this.buttonApprove.Text = "Approve";
            this.buttonApprove.UseVisualStyleBackColor = true;
            this.buttonApprove.Click += new System.EventHandler(this.buttonApprove_Click);
            //
            // buttonReject
            //
            this.buttonReject.Location = new System.Drawing.Point(263, 210);
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.Size = new System.Drawing.Size(90, 34);
            this.buttonReject.TabIndex = 9;
            this.buttonReject.Text = "Reject";
            this.buttonReject.UseVisualStyleBackColor = true;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            //
            // buttonClose
            //
            this.buttonClose.Location = new System.Drawing.Point(361, 210);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 34);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            //
            // RequestDetailsDialog
            //
            this.CancelButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 256);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonReject);
            this.Controls.Add(this.buttonApprove);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelReturnDate);
            this.Controls.Add(this.labelRequestedDate);
            this.Controls.Add(this.labelContact);
            this.Controls.Add(this.labelBorrower);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelBook);
            this.Controls.Add(this.pictureBoxCover);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Name = "RequestDetailsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RequestDetailsDialog";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Label labelBook;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelBorrower;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.Label labelRequestedDate;
        private System.Windows.Forms.Label labelReturnDate;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonApprove;
        private System.Windows.Forms.Button buttonReject;
        private System.Windows.Forms.Button buttonClose;
    }
}
