using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class AddBooks : UserControl
    {
        private readonly BookService _bookService = new BookService();
        private int _selectedBookId;

        public AddBooks()
        {
            InitializeComponent();
            DisplayBooks();
        }

        public void RefreshData()
        {
            if (InvokeRequired) { Invoke((MethodInvoker)RefreshData); return; }
            DisplayBooks();
        }

        private void DisplayBooks()
        {
            try
            {
                dataGridView1.DataSource = _bookService.GetAllBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            BookTitle.Text = "";
            Author.Text = "";
            Add_PictureBox.Image = null;
            Status.SelectedIndex = -1;
            _selectedBookId = 0;
        }

        private bool ValidateForm()
        {
            return Add_PictureBox.Image != null &&
                   !string.IsNullOrWhiteSpace(BookTitle.Text) &&
                   !string.IsNullOrWhiteSpace(Author.Text) &&
                   !string.IsNullOrWhiteSpace(Status.Text);
        }

        private void buttonImport_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    Add_PictureBox.ImageLocation = dialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing image: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string imagePath = _bookService.SaveBookImage(
                    Add_PictureBox.ImageLocation,
                    BookTitle.Text.Trim(),
                    Author.Text.Trim());

                var book = new Bookk
                {
                    Book_Title = BookTitle.Text.Trim(),
                    Author = Author.Text.Trim(),
                    Published_Date = PublishedDate.Value,
                    Book_Status = Status.Text.Trim(),
                    Image = imagePath,
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
                MessageBox.Show("Error adding book: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            _selectedBookId = (int)row.Cells[0].Value;
            BookTitle.Text = row.Cells[1].Value?.ToString();
            Author.Text = row.Cells[2].Value?.ToString();
            PublishedDate.Text = row.Cells[3].Value?.ToString();
            Status.Text = row.Cells[4].Value?.ToString();

            string imagePath = row.Cells[7].Value?.ToString();
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                try { Add_PictureBox.Image = Image.FromFile(imagePath); }
                catch { Add_PictureBox.Image = null; }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
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
                MessageBox.Show("Error updating book: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error deleting book: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
