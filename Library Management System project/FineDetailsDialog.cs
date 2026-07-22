using System;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    // Read-only detail view for one row of the staff Fines report. No action
    // buttons here - payment is borrower-only (see BorrowerFines.Payment.cs);
    // this dialog exists so staff can see the full picture behind a report
    // row without any payment control ever appearing on the staff side.
    public partial class FineDetailsDialog : Form
    {
        public FineDetailsDialog(FineRecord fine)
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Text = "Fine Details";

            labelBook.Text = fine.Book_Title;
            labelBorrower.Text = $"Borrower: {fine.Full_Name} ({fine.Email})";
            labelOverdue.Text = $"Overdue by: {fine.Overdue_Days} day(s)";
            labelAmount.Text = $"Amount: RM {fine.Amount:F2}";
            labelStatus.Text = "Status: " + fine.Status;
            labelStatus.ForeColor = fine.Status == "Paid"
                ? System.Drawing.Color.SeaGreen
                : System.Drawing.Color.Firebrick;
            labelAssessedDate.Text = "Assessed: " + fine.Assessed_Date.ToString("dd/MM/yyyy HH:mm");
            labelPaidDate.Text = "Paid: " + (fine.Paid_Date.HasValue
                ? fine.Paid_Date.Value.ToString("dd/MM/yyyy HH:mm")
                : "Not yet paid");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
