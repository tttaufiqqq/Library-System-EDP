using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
            GridStyleHelper.Apply(dataGridView1);
            ComboBoxStyleHelper.Apply(Status);
            PublishedDate.MaxDate = DateTime.Today;
            SetButtonIcons();
            ArrowKeyNavigationHelper.Enable(this);
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            DisplayBooks();
        }

        private void SetButtonIcons()
        {
            buttonAdd.Image = Properties.Resources.IconAdd;
            buttonUpdate.Image = Properties.Resources.IconUpdate;
            buttonDelete.Image = Properties.Resources.IconDelete;
            buttonClear.Image = Properties.Resources.IconClear;
            buttonAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonClear.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        public void RefreshData()
        {
            if (InvokeRequired) { Invoke((MethodInvoker)RefreshData); return; }
            DisplayBooks();
        }

        public void SetCanDelete(bool canDelete) => buttonDelete.Visible = canDelete;

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
                EmptyStateHelper.Toggle(dataGridView1, books.Count == 0, "No books found.", Color.Black);
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

        private void labelSearch_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
