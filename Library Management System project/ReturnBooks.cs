using System;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class ReturnBooks : UserControl
    {
        private readonly IssueService _issueService = new IssueService();
        private readonly BookService _bookService = new BookService();

        public ReturnBooks()
        {
            InitializeComponent();
            DisplayIssuedBooks();
            toolStripStatusLabel1.Text = "";
        }

        public void DisplayIssuedBooks()
        {
            try
            {
                var listData = _issueService.GetActiveIssues()
                    .Select(ib => new
                    {
                        ib.IssueID,
                        ib.Full_Name,
                        ib.Contact,
                        ib.Email,
                        ib.Book_Title,
                        ib.Author,
                        ib.Issue_Date,
                        ib.Image
                    }).ToList();

                dataGridView1.DataSource = listData;
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading issued books", ex);
            }
        }

        public void refreshData()
        {
            if (InvokeRequired) { Invoke((MethodInvoker)refreshData); return; }
            DisplayIssuedBooks();
        }

        private void ClearFields()
        {
            return_author.Text = "";
            return_IssueID.Text = "";
            return_name.Text = "";
            return_email.Text = "";
            return_contact.Text = "";
            return_bookTitle.Text = "";
            return_dateIssued.Text = "";
            return_pictureBox.Image = null;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(return_IssueID.Text))
            {
                MessageBox.Show("Please select an issue first.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure that Issue ID: " + return_IssueID.Text.Trim() +
                " is returned already?", "Confirmation Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _issueService.ReturnBook(return_IssueID.Text.Trim());
                MessageBox.Show("Successfully Returned",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                DisplayIssuedBooks();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error returning book", ex);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                return_IssueID.Text = row.Cells["IssueID"]?.Value?.ToString() ?? "";
                return_name.Text = row.Cells["Full_Name"]?.Value?.ToString() ?? "";
                return_contact.Text = row.Cells["Contact"]?.Value?.ToString() ?? "";
                return_email.Text = row.Cells["Email"]?.Value?.ToString() ?? "";
                return_bookTitle.Text = row.Cells["Book_Title"]?.Value?.ToString() ?? "";
                return_author.Text = row.Cells["Author"]?.Value?.ToString() ?? "";
                return_dateIssued.Value = row.Cells["Issue_Date"]?.Value != null
                    ? Convert.ToDateTime(row.Cells["Issue_Date"].Value) : DateTime.Today;

                string bookTitle = row.Cells["Book_Title"]?.Value?.ToString();
                if (!string.IsNullOrEmpty(bookTitle))
                {
                    string imageKey = _bookService.GetBookImageKey(bookTitle);
                    return_pictureBox.Image = _bookService.LoadBookImage(imageKey);
                }
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error selecting issue", ex);
            }
        }

        private void changefont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.OK) return;
            dataGridView1.Font = fontDialog1.Font;
            return_author.Font = fontDialog1.Font;
            return_IssueID.Font = fontDialog1.Font;
            return_name.Font = fontDialog1.Font;
            return_email.Font = fontDialog1.Font;
            return_contact.Font = fontDialog1.Font;
            return_bookTitle.Font = fontDialog1.Font;
            return_dateIssued.Font = fontDialog1.Font;
        }

        private void return_IssueID_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display Issue ID";
        private void return_IssueID_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
        private void return_name_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display borrower's name";
        private void return_name_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
        private void return_contact_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
        private void return_contact_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display borrower's contact number";
        private void return_email_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display borrower's email address";
        private void return_email_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
        private void return_bookTitle_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display Book Title";
        private void return_bookTitle_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
        private void return_author_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display Book Author";
        private void return_author_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
    }
}
