using System;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class ReturnConfirmDialog : Form
    {
        private readonly IssuesBook _issue;

        public bool Confirmed { get; private set; }

        public ReturnConfirmDialog(IssuesBook issue)
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Text = "Confirm Return";

            _issue = issue;

            labelBook.Text = issue.Book_Title;
            labelAuthor.Text = "Author: " + (issue.Author ?? "Unknown");
            labelBorrower.Text = $"Borrower: {issue.Full_Name} ({issue.Email})";
            labelContact.Text = "Contact: " + issue.Contact;
            labelIssueDate.Text = "Issued: " + issue.Issue_Date;
            labelReturnDate.Text = "Due: " + issue.Return_Date;
            labelRequestedDate.Text = "Return requested: " + issue.Return_Requested_Date?.ToString("yyyy-MM-dd HH:mm");

            string imageKey = new BookService().GetBookImageKey(issue.Book_Title);
            pictureBoxCover.Image = new BookService().LoadBookImage(imageKey);
        }

        private void buttonConfirmReturn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm that this book has been physically returned?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new IssueService().ReturnBook(_issue.IssueID);
                MessageBox.Show("Successfully Returned",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Confirmed = true;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error returning book", ex);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
