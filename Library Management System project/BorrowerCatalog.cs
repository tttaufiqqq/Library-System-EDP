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
            GridStyleHelper.Apply(dataGridView1);
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
                LoadingOverlay.Show(this);
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
                GridStyleHelper.FormatDateColumns(dataGridView1);
                EmptyStateHelper.Toggle(dataGridView1, books.Count == 0, "No books found.", Color.White);
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading books", ex);
            }
            finally
            {
                LoadingOverlay.Hide(this);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayBooks();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var book = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bookk;
            if (book == null) return;

            using (var dialog = new BookDetailsDialog(book, _email, _fullName))
            {
                dialog.ShowDialog();
            }
        }
    }
}
