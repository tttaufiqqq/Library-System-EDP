using System;
using System.Data;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class IssuedBooks
    {
        private bool ValidateIssueForm(string context)
        {
            if (bookIssue_id.Text == "" || bookIssue_name.Text == "" ||
                bookIssue_contact.Text == "" || bookIssue_email.Text == "" ||
                bookIssue_bookTitle.Text == "" || bookIssue_author.Text == "" ||
                bookIssue_status.Text == "" || bookIssue_picturbox.Image == null)
            {
                MessageBox.Show(context,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!InputValidator.IsValidEmail(bookIssue_email.Text))
            {
                MessageBox.Show("Please enter a valid email address.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!InputValidator.IsValidPhone(bookIssue_contact.Text))
            {
                MessageBox.Show("Please enter a valid contact number.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void bookIssue_Add_Click(object sender, EventArgs e)
        {
            if (!ValidateIssueForm("Please fill all the required fields")) return;

            if (bookIssue_issueDate.Value.Date != DateTime.Today)
            {
                MessageBox.Show("Issue date must be today.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bookIssue_returnDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Return date cannot be in the past.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var newIssue = new IssuesBook
                {
                    IssueID = bookIssue_id.Text.Trim(),
                    Full_Name = bookIssue_name.Text.Trim(),
                    Author = bookIssue_author.Text.Trim(),
                    Contact = bookIssue_contact.Text.Trim(),
                    Email = bookIssue_email.Text.Trim(),
                    Book_Title = bookIssue_bookTitle.Text.Trim(),
                    Image = _currentBookImageKey ?? "",
                    Return_Status = bookIssue_status.Text.Trim(),
                    Issue_Date = bookIssue_issueDate.Value.ToString(),
                    Return_Date = bookIssue_returnDate.Value.ToString(),
                    Insert_Date = DateTime.Today.ToString()
                };

                _issueService.IssueBook(newIssue);

                displayBookIssueData();
                MessageBox.Show("Issued Successfully!",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error issuing book", ex);
            }
        }

        private void bookIssue_bookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bookIssue_bookTitle.SelectedValue == null) return;

            DataRowView selectedRow = (DataRowView)bookIssue_bookTitle.SelectedItem;
            int selectedID = Convert.ToInt32(selectedRow["BookID"]);
            try
            {
                var book = _bookService.GetBookById(selectedID);
                if (book == null) return;

                bookIssue_author.Text = book.Author;
                string imageKey = book.Image;

                bookIssue_picturbox.Image = _bookService.LoadBookImage(imageKey);
                _currentBookImageKey = !string.IsNullOrEmpty(imageKey) ? imageKey : null;
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading book details", ex);
            }
        }

        private void bookIssue_Update_Click(object sender, EventArgs e)
        {
            if (!ValidateIssueForm("Please select a book first.")) return;

            if (MessageBox.Show("Are you sure you want to UPDATE Issue ID: " + bookIssue_id.Text + " ?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                MessageBox.Show("Cancelled.", "Information Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool updated = _issueService.UpdateIssue(
                    bookIssue_id.Text.Trim(),
                    bookIssue_name.Text.Trim(),
                    bookIssue_contact.Text.Trim(),
                    bookIssue_email.Text.Trim(),
                    bookIssue_bookTitle.Text.Trim(),
                    bookIssue_author.Text.Trim(),
                    bookIssue_status.Text.Trim(),
                    bookIssue_issueDate.Value,
                    bookIssue_returnDate.Value);

                if (!updated)
                {
                    MessageBox.Show("Issue not found.", "Error Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                displayBookIssueData();
                MessageBox.Show("Issue Successfully Updated",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error updating issue", ex);
            }
        }

        private void bookIssue_Delete_Click(object sender, EventArgs e)
        {
            if (!ValidateIssueForm("Please select a book first")) return;

            if (MessageBox.Show("Are you sure you want to DELETE Issue ID: " + bookIssue_id.Text.Trim() + " ?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                MessageBox.Show("Cancelled.", "Information Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool deleted = _issueService.DeleteIssue(bookIssue_id.Text.Trim());

                if (!deleted)
                {
                    MessageBox.Show("Issue not found.", "Error Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                displayBookIssueData();
                MessageBox.Show("Issue Successfully Deleted", "Information Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error deleting issue", ex);
            }
        }
    }
}
