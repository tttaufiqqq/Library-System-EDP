namespace Library_Management_System_project
{
    partial class RequestBookDialog
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
            this.labelBookCaption = new System.Windows.Forms.Label();
            this.labelBookTitleValue = new System.Windows.Forms.Label();
            this.labelAuthorCaption = new System.Windows.Forms.Label();
            this.labelAuthorValue = new System.Windows.Forms.Label();
            this.labelContact = new System.Windows.Forms.Label();
            this.textBoxContact = new System.Windows.Forms.TextBox();
            this.labelReturnBy = new System.Windows.Forms.Label();
            this.dateTimePickerReturn = new System.Windows.Forms.DateTimePicker();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // labelBookCaption
            //
            this.labelBookCaption.AutoSize = true;
            this.labelBookCaption.Location = new System.Drawing.Point(12, 18);
            this.labelBookCaption.Name = "labelBookCaption";
            this.labelBookCaption.Size = new System.Drawing.Size(37, 13);
            this.labelBookCaption.TabIndex = 0;
            this.labelBookCaption.Text = "Book:";
            //
            // labelBookTitleValue
            //
            this.labelBookTitleValue.AutoSize = true;
            this.labelBookTitleValue.Location = new System.Drawing.Point(95, 18);
            this.labelBookTitleValue.Name = "labelBookTitleValue";
            this.labelBookTitleValue.Size = new System.Drawing.Size(0, 13);
            this.labelBookTitleValue.TabIndex = 1;
            //
            // labelAuthorCaption
            //
            this.labelAuthorCaption.AutoSize = true;
            this.labelAuthorCaption.Location = new System.Drawing.Point(12, 48);
            this.labelAuthorCaption.Name = "labelAuthorCaption";
            this.labelAuthorCaption.Size = new System.Drawing.Size(45, 13);
            this.labelAuthorCaption.TabIndex = 2;
            this.labelAuthorCaption.Text = "Author:";
            //
            // labelAuthorValue
            //
            this.labelAuthorValue.AutoSize = true;
            this.labelAuthorValue.Location = new System.Drawing.Point(95, 48);
            this.labelAuthorValue.Name = "labelAuthorValue";
            this.labelAuthorValue.Size = new System.Drawing.Size(0, 13);
            this.labelAuthorValue.TabIndex = 3;
            //
            // labelContact
            //
            this.labelContact.AutoSize = true;
            this.labelContact.Location = new System.Drawing.Point(12, 88);
            this.labelContact.Name = "labelContact";
            this.labelContact.Size = new System.Drawing.Size(50, 13);
            this.labelContact.TabIndex = 4;
            this.labelContact.Text = "Contact:";
            //
            // textBoxContact
            //
            this.textBoxContact.Location = new System.Drawing.Point(95, 85);
            this.textBoxContact.Name = "textBoxContact";
            this.textBoxContact.Size = new System.Drawing.Size(200, 20);
            this.textBoxContact.TabIndex = 5;
            //
            // labelReturnBy
            //
            this.labelReturnBy.AutoSize = true;
            this.labelReturnBy.Location = new System.Drawing.Point(12, 124);
            this.labelReturnBy.Name = "labelReturnBy";
            this.labelReturnBy.Size = new System.Drawing.Size(60, 13);
            this.labelReturnBy.TabIndex = 6;
            this.labelReturnBy.Text = "Return by:";
            //
            // dateTimePickerReturn
            //
            this.dateTimePickerReturn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerReturn.Location = new System.Drawing.Point(95, 118);
            this.dateTimePickerReturn.Name = "dateTimePickerReturn";
            this.dateTimePickerReturn.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerReturn.TabIndex = 7;
            //
            // buttonConfirm
            //
            this.buttonConfirm.Location = new System.Drawing.Point(95, 160);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(90, 30);
            this.buttonConfirm.TabIndex = 8;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            //
            // buttonCancel
            //
            this.buttonCancel.Location = new System.Drawing.Point(205, 160);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 30);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            //
            // RequestBookDialog
            //
            this.AcceptButton = this.buttonConfirm;
            this.CancelButton = this.buttonCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 210);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.dateTimePickerReturn);
            this.Controls.Add(this.labelReturnBy);
            this.Controls.Add(this.textBoxContact);
            this.Controls.Add(this.labelContact);
            this.Controls.Add(this.labelAuthorValue);
            this.Controls.Add(this.labelAuthorCaption);
            this.Controls.Add(this.labelBookTitleValue);
            this.Controls.Add(this.labelBookCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestBookDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RequestBookDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBookCaption;
        private System.Windows.Forms.Label labelBookTitleValue;
        private System.Windows.Forms.Label labelAuthorCaption;
        private System.Windows.Forms.Label labelAuthorValue;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.TextBox textBoxContact;
        private System.Windows.Forms.Label labelReturnBy;
        private System.Windows.Forms.DateTimePicker dateTimePickerReturn;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
    }
}
