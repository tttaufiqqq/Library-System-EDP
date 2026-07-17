using System;
using System.Data;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class IssuedBooks : UserControl
    {
        private readonly IssueService _issueService = new IssueService();
        private readonly BookService _bookService = new BookService();
        private string _currentBookImageKey;

        public IssuedBooks()
        {
            InitializeComponent();
            DataBookTitle();
            displayBookIssueData();
            toolStripStatusLabel1.Text = "";
        }

        public void refreshData()
        {
            if (InvokeRequired) { Invoke((MethodInvoker)refreshData); return; }
            DataBookTitle();
            displayBookIssueData();
            clearFields();
        }

        public void displayBookIssueData()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _issueService.GetIssueDisplayData();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error displaying issues", ex);
            }
        }

        public void clearFields()
        {
            bookIssue_id.Text = "";
            bookIssue_name.Text = "";
            bookIssue_contact.Text = "";
            bookIssue_email.Text = "";
            bookIssue_bookTitle.Text = "";
            bookIssue_author.Text = "";
            bookIssue_issueDate.Value = DateTime.Today;
            bookIssue_returnDate.Value = DateTime.Today;
            bookIssue_status.Text = "";
            bookIssue_picturbox.Image = null;
            _currentBookImageKey = null;
        }

        public void DataBookTitle()
        {
            var table = new DataTable();
            table.Columns.Add("BookID", typeof(int));
            table.Columns.Add("Book_Title", typeof(string));

            foreach (var book in _bookService.GetAvailableBooks())
                table.Rows.Add(book.BookID, book.Book_Title);

            bookIssue_bookTitle.DataSource = table;
            bookIssue_bookTitle.DisplayMember = "Book_Title";
            bookIssue_bookTitle.ValueMember = "BookID";
        }
    }
}
