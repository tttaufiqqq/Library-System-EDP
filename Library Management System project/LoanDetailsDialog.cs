using System;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class LoanDetailsDialog : Form
    {
        private readonly IssuesBook _issue;

        public bool RequestSubmitted { get; private set; }

        public LoanDetailsDialog(IssuesBook issue)
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Text = "Loan Details";

            _issue = issue;

            labelBook.Text = issue.Book_Title;
            labelAuthor.Text = "Author: " + (issue.Author ?? "Unknown");
            labelIssueDate.Text = "Issued: " + issue.Issue_Date;
            labelReturnDate.Text = "Due: " + issue.Return_Date;
            labelStatus.Text = "Status: " + issue.Return_Status;

            string imageKey = new BookService().GetBookImageKey(issue.Book_Title);
            pictureBoxCover.Image = new BookService().LoadBookImage(imageKey);

            if (issue.Return_Status != "Not Returned")
            {
                buttonRequestReturn.Enabled = false;
                labelNote.Text = "This book has already been returned.";
            }
            else if (issue.Return_Requested_Date != null)
            {
                buttonRequestReturn.Enabled = false;
                labelNote.Text = "Return already requested, pending staff confirmation.";
            }
            else
            {
                buttonRequestReturn.Enabled = true;
                labelNote.Text = "";
            }
        }

        private void buttonRequestReturn_Click(object sender, EventArgs e)
        {
            try
            {
                new IssueService().RequestReturn(_issue.IssueID);
                MessageBox.Show("Return requested. Staff will confirm once the book is verified.",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RequestSubmitted = true;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error requesting return", ex);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
