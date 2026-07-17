using System;

namespace Library_Management_System_project
{
    public partial class IssuedBooks
    {
        private void bookIssue_id_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Issue ID.";
        }

        private void bookIssue_id_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void bookIssue_name_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter borrower's name";
        }

        private void bookIssue_name_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void bookIssue_email_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter borrower's email.";
        }

        private void bookIssue_email_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void bookIssue_contact_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter borrower's contact number.";
        }

        private void bookIssue_contact_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
