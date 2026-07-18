using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class BorrowerCatalog : UserControl
    {
        private readonly BookService _bookService = new BookService();
        private string _email;
        private string _fullName;

        public BorrowerCatalog()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            DisplayBooks();
        }

        public void SetUser(User user)
        {
            _email = user.email;
            _fullName = user.username;
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
                var books = _bookService.GetAllBooks();
                string term = textBoxSearch.Text.Trim();

                if (!string.IsNullOrEmpty(term))
                {
                    books = books.Where(b =>
                        (b.Book_Title != null && b.Book_Title.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (b.Author != null && b.Author.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                    ).ToList();
                }

                dataGridView1.DataSource = books;
                EmptyStateHelper.Toggle(dataGridView1, books.Count == 0, "No books found.", Color.White);
                UpdateRequestButtonState();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading books", ex);
            }
        }

        private Bookk GetSelectedBook()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return dataGridView1.SelectedRows[0].DataBoundItem as Bookk;
        }

        private void UpdateRequestButtonState()
        {
            var book = GetSelectedBook();
            buttonRequestBook.Enabled = book != null && book.Book_Status == "Available";
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayBooks();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateRequestButtonState();
        }

        private void buttonRequestBook_Click(object sender, EventArgs e)
        {
            var book = GetSelectedBook();
            if (book == null) return;

            using (var dialog = new RequestBookDialog(book.Book_Title, book.Author))
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;

                var check = BorrowingPolicy.Check(_email, book.BookID, book.Book_Title, book.Book_Status);
                if (!check.Ok)
                {
                    MessageBox.Show(check.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    new RequestService().CreateRequest(new BookRequest
                    {
                        Email = _email,
                        Full_Name = _fullName,
                        Contact = dialog.Contact,
                        BookID = book.BookID,
                        Book_Title = book.Book_Title,
                        Author = book.Author,
                        Requested_Date = DateTime.Today,
                        Return_Date = dialog.ReturnDate,
                        Status = "Pending"
                    });

                    MessageBox.Show("Request submitted, pending staff approval.",
                        "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ErrorPresenter.Show("Error submitting request", ex);
                }
            }
        }
    }
}
