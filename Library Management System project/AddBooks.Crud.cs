using System;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class AddBooks
    {
        private void buttonImport_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    Add_PictureBox.ImageLocation = dialog.FileName;
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error importing image", ex);
            }
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Please fill all the required fields",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string imageKey = _bookService.SaveBookImage(
                    Add_PictureBox.ImageLocation,
                    BookTitle.Text.Trim(),
                    Author.Text.Trim());

                var book = new Bookk
                {
                    Book_Title = BookTitle.Text.Trim(),
                    Author = Author.Text.Trim(),
                    Published_Date = PublishedDate.Value,
                    Book_Status = Status.Text.Trim(),
                    Image = imageKey,
                    Date_Insert = DateTime.Today
                };

                _bookService.AddBook(book);
                DisplayBooks();
                MessageBox.Show("Book Successfully Added",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error adding book", ex);
            }
        }

        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Please select a book first",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to UPDATE Book ID: " + _selectedBookId + " ?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _bookService.UpdateBook(
                    _selectedBookId,
                    BookTitle.Text.Trim(),
                    Author.Text.Trim(),
                    PublishedDate.Value,
                    Status.Text.Trim(),
                    null);

                DisplayBooks();
                MessageBox.Show("Book Successfully Updated",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error updating book", ex);
            }
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Please select a book first",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to DELETE Book ID: " + _selectedBookId + " ?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _bookService.SoftDeleteBook(_selectedBookId);
                DisplayBooks();
                MessageBox.Show("Book Successfully Deleted",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error deleting book", ex);
            }
        }

        private void openFileForBookCoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    Add_PictureBox.ImageLocation = dialog.FileName;
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error importing image", ex);
            }
        }
    }
}
