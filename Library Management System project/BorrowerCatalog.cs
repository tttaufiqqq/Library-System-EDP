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

        public BorrowerCatalog()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
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
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading books", ex);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayBooks();
        }
    }
}
