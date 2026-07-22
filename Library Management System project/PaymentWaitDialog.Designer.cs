namespace Library_Management_System_project
{
    partial class PaymentWaitDialog
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
            this.timerPoll = new System.Windows.Forms.Timer(this.components);
            this.labelHeading = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.loadingSpinner1 = new Library_Management_System_project.LoadingSpinner();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // timerPoll
            //
            this.timerPoll.Tick += new System.EventHandler(this.timerPoll_Tick);
            //
            // labelHeading
            //
            this.labelHeading.AutoSize = false;
            this.labelHeading.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeading.Location = new System.Drawing.Point(12, 15);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Size = new System.Drawing.Size(376, 30);
            this.labelHeading.TabIndex = 0;
            this.labelHeading.Text = "Complete your payment in the browser";
            this.labelHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // labelAmount
            //
            this.labelAmount.AutoSize = false;
            this.labelAmount.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmount.Location = new System.Drawing.Point(12, 48);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(376, 24);
            this.labelAmount.TabIndex = 1;
            this.labelAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // loadingSpinner1
            //
            this.loadingSpinner1.Location = new System.Drawing.Point(182, 84);
            this.loadingSpinner1.Name = "loadingSpinner1";
            this.loadingSpinner1.Size = new System.Drawing.Size(36, 36);
            this.loadingSpinner1.TabIndex = 2;
            //
            // labelStatus
            //
            this.labelStatus.AutoSize = false;
            this.labelStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.DimGray;
            this.labelStatus.Location = new System.Drawing.Point(12, 128);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(376, 24);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Waiting for payment confirmation...";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // buttonCancel
            //
            this.buttonCancel.Location = new System.Drawing.Point(129, 162);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(140, 34);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            //
            // PaymentWaitDialog
            //
            this.CancelButton = this.buttonCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 212);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.loadingSpinner1);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelHeading);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentWaitDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Waiting for Payment";
            this.Load += new System.EventHandler(this.PaymentWaitDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerPoll;
        private System.Windows.Forms.Label labelHeading;
        private System.Windows.Forms.Label labelAmount;
        private Library_Management_System_project.LoadingSpinner loadingSpinner1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonCancel;
    }
}
