using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.IO;

namespace Library_Management_System_project
{
    public partial class IssuedBooks : UserControl
    {
        SqlConnection connect = new SqlConnection
            (@"Server=CHANGE_ME;Initial Catalog=Library;User Id=CHANGE_ME;Password=CHANGE_ME;Connect Timeout=30");

        private string _currentBookImagePath;

        public IssuedBooks()
        {
            InitializeComponent();           
            DataBookTitle();
            displayBookIssueData();
            toolStripStatusLabel1.Text = "";
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            DataBookTitle();
            displayBookIssueData();
            clearFields();
        }

        public void displayBookIssueData()
        {
            try
            {
                DataIssueBooks dib = new DataIssueBooks();
                List<DataIssueBooks> listData = dib.IssueBooksData();

                dataGridView1.DataSource = null; // Clear existing data
                dataGridView1.DataSource = listData;
                dataGridView1.Refresh(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in displayBookIssueData: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _currentBookImagePath = null;
        }

        private void bookIssue_Add_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            if (bookIssue_id.Text == "" || bookIssue_name.Text == "" ||
                bookIssue_contact.Text == "" || bookIssue_email.Text == "" ||
                bookIssue_bookTitle.Text == "" || bookIssue_author.Text == "" ||
                bookIssue_issueDate.Value == null || bookIssue_returnDate.Value == null ||
                bookIssue_status.Text == "" || bookIssue_picturbox.Image == null)
            {
                MessageBox.Show("Please fill all the required fields",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (LibraryDataContext context = new LibraryDataContext())
                    {
                        IssuesBook newIssue = new IssuesBook
                        {
                            IssueID = bookIssue_id.Text.Trim(),
                            Full_Name = bookIssue_name.Text.Trim(),
                            Author = bookIssue_author.Text.Trim(),
                            Contact = bookIssue_contact.Text.Trim(),
                            Email = bookIssue_email.Text.Trim(),
                            Book_Title = bookIssue_bookTitle.Text.Trim(),
                            Image = _currentBookImagePath ?? "",
                            Return_Status = bookIssue_status.Text.Trim(),
                            Issue_Date = bookIssue_issueDate.Value.ToString(),
                            Return_Date = bookIssue_returnDate.Value.ToString(),
                            Insert_Date = today.ToString()
                        };

                        // Insert the new issue into the context
                        context.IssuesBooks.InsertOnSubmit(newIssue);

                        // Submit changes to the database
                        context.SubmitChanges();

                        // Refresh the data grid and clear the fields
                        displayBookIssueData();
                        MessageBox.Show("Issued Successfully!",
                            "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in bookIssue_Add_Click: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DataBookTitle()
        {
            using (var context = new LibraryDataContext())
            {
                var books = from book in context.Bookks
                            where book.Book_Status == "Available"
                            select new { book.BookID, book.Book_Title };

                var table = new DataTable();
                table.Columns.Add("BookID", typeof(int));
                table.Columns.Add("Book_Title", typeof(string));

                foreach (var book in books)
                {
                    table.Rows.Add(book.BookID, book.Book_Title);
                }

                bookIssue_bookTitle.DataSource = table;
                bookIssue_bookTitle.DisplayMember = "Book_Title";
                bookIssue_bookTitle.ValueMember = "BookID";
            }
        }


        private void bookIssue_bookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (connect.State != ConnectionState.Open)
            {
                if (bookIssue_bookTitle.SelectedValue != null)
                {
                    DataRowView selectedRow = (DataRowView)bookIssue_bookTitle.SelectedItem;
                    int selectedID = Convert.ToInt32(selectedRow["BookID"]);
                    try
                    {
                        if (connect.State != ConnectionState.Open)
                        {
                            connect.Open();
                        }
                        string selectData = "SELECT * FROM Books WHERE BookID = @BookID";
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@BookID", selectedID);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                bookIssue_author.Text = table.Rows[0]["Author"].ToString();
                                string imagePath = table.Rows[0]["Image"].ToString();

                                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                                {
                                    bookIssue_picturbox.Image = Image.FromFile(imagePath);
                                    _currentBookImagePath = imagePath;
                                }
                                else
                                {
                                    bookIssue_picturbox.Image = null;
                                    _currentBookImagePath = null;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in bookIssue_bookTitle_SelectedIndexChanged: " + ex.Message,
                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }

        private void bookIssue_Update_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            if (bookIssue_id.Text == "" || bookIssue_name.Text == "" ||
                bookIssue_contact.Text == "" || bookIssue_email.Text == "" ||
                bookIssue_bookTitle.Text == "" || bookIssue_author.Text == "" ||
                bookIssue_issueDate.Value == null || bookIssue_returnDate.Value == null ||
                bookIssue_status.Text == "" || bookIssue_picturbox.Image == null)
            {
                MessageBox.Show("Please select a book first.",
                   "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Issue ID: "
                    + bookIssue_id.Text + " ?", "Confirmation Message", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    try
                    {
                        using (LibraryDataContext context = new LibraryDataContext())
                        {
                            var issueToUpdate = context.IssuesBooks.SingleOrDefault(issue => issue.IssueID == bookIssue_id.Text.Trim());

                            if (issueToUpdate != null)
                            {
                                issueToUpdate.Full_Name = bookIssue_name.Text.Trim();
                                issueToUpdate.Contact = bookIssue_contact.Text.Trim();
                                issueToUpdate.Email = bookIssue_email.Text.Trim();
                                issueToUpdate.Book_Title = bookIssue_bookTitle.Text.Trim();
                                issueToUpdate.Author = bookIssue_author.Text.Trim();
                                issueToUpdate.Return_Status = bookIssue_status.Text.Trim();
                                issueToUpdate.Issue_Date = bookIssue_issueDate.Value.ToString("yyyy-MM-dd");
                                issueToUpdate.Return_Date = bookIssue_returnDate.Value.ToString("yyyy-MM-dd");
                                issueToUpdate.Date_Update = today.ToString("yyyy-MM-dd");

                                context.SubmitChanges();

                                displayBookIssueData();
                                MessageBox.Show("Issue Successfully Updated",
                                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                            else
                            {
                                MessageBox.Show("Issue not found.", "Error Message",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in bookIssue_Update_Click: " +
                            ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled.", "Information Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    bookIssue_id.Text = row.Cells[1]?.Value?.ToString() ?? string.Empty;
                    bookIssue_name.Text = row.Cells[2]?.Value?.ToString() ?? string.Empty;
                    bookIssue_contact.Text = row.Cells[3]?.Value?.ToString() ?? string.Empty;
                    bookIssue_email.Text = row.Cells[4]?.Value?.ToString() ?? string.Empty;
                    bookIssue_bookTitle.Text = row.Cells[5]?.Value?.ToString() ?? string.Empty;
                    bookIssue_author.Text = row.Cells[6]?.Value?.ToString() ?? string.Empty;
                    bookIssue_status.Text = row.Cells[10]?.Value?.ToString() ?? string.Empty;
                    bookIssue_issueDate.Value = row.Cells[9]?.Value != null ?
                        Convert.ToDateTime(row.Cells[9].Value) : DateTime.Today;
                    bookIssue_returnDate.Value = row.Cells[8]?.Value != null ?
                        Convert.ToDateTime(row.Cells[8].Value) : DateTime.Today;

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in dataGridView1_CellClick: " +
                    ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bookIssue_Delete_Click(object sender, EventArgs e)
        {
            if (bookIssue_id.Text == "" || bookIssue_name.Text == "" ||
                bookIssue_contact.Text == "" || bookIssue_email.Text == "" ||
                bookIssue_bookTitle.Text == "" || bookIssue_author.Text == "" ||
                bookIssue_issueDate.Value == null || bookIssue_returnDate.Value == null ||
                bookIssue_status.Text == "" || bookIssue_picturbox.Image == null)
            {
                MessageBox.Show("Please select a book first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Are you sure you want to DELETE Issue ID: " + bookIssue_id.Text.Trim() + " ?",
                    "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    try
                    {
                        using (LibraryDataContext context = new LibraryDataContext())
                        {
                            var issueToDelete = context.IssuesBooks.SingleOrDefault
                                (issue => issue.IssueID == bookIssue_id.Text.Trim());

                            if (issueToDelete != null)
                            {
                                context.IssuesBooks.DeleteOnSubmit(issueToDelete);
                                context.SubmitChanges();

                                displayBookIssueData();
                                MessageBox.Show("Issue Successfully Deleted", "Information Message",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                            else
                            {
                                MessageBox.Show("Issue not found.", "Error Message",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error Message", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cancelled.", "Information Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bookIssue_Clear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void bookIssue_id_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Issue ID.";
        }

        private void bookIssue_id_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void bookIssue_name_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter borrower's name";
        }

        private void bookIssue_name_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void bookIssue_email_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter borrower's email.";
        }

        private void bookIssue_email_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void bookIssue_contact_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter borrower's contact number.";
        }

        private void bookIssue_contact_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
