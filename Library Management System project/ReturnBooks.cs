using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Management_System_project
{
    public partial class ReturnBooks : UserControl
    {
        // Assuming you have created LibraryDataContext using LINQ to SQL
        private LibraryDataContext context;

        public ReturnBooks()
        {
            InitializeComponent();
            context = new LibraryDataContext();
            displayIssuedBooksData();
            toolStripStatusLabel1.Text = "";
        }

        public void displayIssuedBooksData()
        {
            var listData = context.IssuesBooks
                .Where(ib => ib.Return_Status != "Returned")
                .Select(ib => new
                {
                    ib.IssueID,
                    ib.Full_Name,
                    ib.Contact,
                    ib.Email,
                    ib.Book_Title,
                    ib.Author,
                    ib.Issue_Date,
                    ib.Image // Assuming Image is a part of IssuesBooks
                })
                .ToList();

            dataGridView1.DataSource = listData;
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayIssuedBooksData();
        }

        public void clearFields()
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
            DateTime today = DateTime.Today;
            if (string.IsNullOrEmpty(return_author.Text) || string.IsNullOrEmpty(return_bookTitle.Text) ||
                string.IsNullOrEmpty(return_contact.Text) || string.IsNullOrEmpty(return_dateIssued.Text) ||
                string.IsNullOrEmpty(return_email.Text) || string.IsNullOrEmpty(return_IssueID.Text) ||
                string.IsNullOrEmpty(return_name.Text) || return_pictureBox.Image == null)
            {
                MessageBox.Show("Please select an issue first.",
                   "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure that Issue ID: " + return_IssueID.Text.Trim() +
                    " is returned already?", "Confirmation Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    try
                    {
                        var issue = context.IssuesBooks.SingleOrDefault(ib => ib.IssueID == return_IssueID.Text.Trim());
                        if (issue != null)
                        {
                            issue.Return_Status = "Returned";
                            issue.Date_Update = DateTime.Now.ToString();
                            context.SubmitChanges();

                            MessageBox.Show("Succesfully Returned",
                            "Information Message", MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                            clearFields();
                            displayIssuedBooksData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message,
                           "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private string GetImagePathFromDatabase(string bookTitle)
        {
            try
            {
                var imagePath = context.Bookks
                    .Where(b => b.Book_Title == bookTitle)
                    .Select(b => b.Image)
                    .SingleOrDefault();

                return imagePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching image path: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Add null checks for each cell
                    return_IssueID.Text = row.Cells["IssueID"]?.Value?.ToString() ?? string.Empty;
                    return_name.Text = row.Cells["Full_Name"]?.Value?.ToString() ?? string.Empty;
                    return_contact.Text = row.Cells["Contact"]?.Value?.ToString() ?? string.Empty;
                    return_email.Text = row.Cells["Email"]?.Value?.ToString() ?? string.Empty;
                    return_bookTitle.Text = row.Cells["Book_Title"]?.Value?.ToString() ?? string.Empty;
                    return_author.Text = row.Cells["Author"]?.Value?.ToString() ?? string.Empty;
                    return_dateIssued.Value = row.Cells["Issue_Date"]?.Value != null ?
                        Convert.ToDateTime(row.Cells["Issue_Date"].Value) : DateTime.Today;

                    string bookTitle = row.Cells["Book_Title"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(bookTitle))
                    {
                        string imagePath = GetImagePathFromDatabase(bookTitle);

                        if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                        {
                            return_pictureBox.Image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            return_pictureBox.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in dataGridView1_CellClick: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changefont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {

                dataGridView1.Font = fontDialog1.Font;
                return_author.Font = fontDialog1.Font;
                return_IssueID.Font = fontDialog1.Font;
                return_name.Font = fontDialog1.Font;
                return_email.Font = fontDialog1.Font;
                return_contact.Font = fontDialog1.Font;
                return_bookTitle.Font = fontDialog1.Font;
                return_dateIssued.Font = fontDialog1.Font;
            }

        }

        private void return_IssueID_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display Issue ID";
        }

        private void return_IssueID_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void return_name_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display borrower's name";
        }

        private void return_name_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void return_contact_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void return_contact_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display borrower's contact number";
        }

        private void return_email_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display borrower's email address";
        }

        private void return_email_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void return_bookTitle_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display Book Title";
        }

        private void return_bookTitle_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void return_author_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display Book Author";
        }

        private void return_author_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
