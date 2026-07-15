using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class AddBooks : UserControl
    {
        public event Action<Bookk> BookAdded;

        public AddBooks()
        {
            InitializeComponent();
            DisplayBook();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DisplayBook();
        }

        public void DisplayBook()
        {
            try
            {
                using (var db = new LibraryDataContext())
                {
                    var books = from book in db.Bookks
                                orderby book.Book_Title 
                                select book;

                    dataGridView1.DataSource = books.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ClearFields()
        {
            BookTitle.Text = "";
            Author.Text = "";
            Add_PictureBox.Image = null;
            Status.SelectedIndex = -1;
        }

        private int BookID = 0;

        private void buttonImport_Click_1(object sender, EventArgs e)
        {
            string imagePath = "";

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    Add_PictureBox.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            if (Add_PictureBox.Image == null ||
                BookTitle.Text == "" || Author.Text == "" ||
                PublishedDate.Value == null || Status.Text == "" || Add_PictureBox.Image == null)
            {
                MessageBox.Show("Please fill all the required fields",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (var db = new LibraryDataContext())
                    {
                        DateTime today = DateTime.Today;

                        string path = Path.Combine(Application.StartupPath, "Books_Directory",
                                                   BookTitle.Text.Trim() + "_" + Author.Text.Trim() + "_" + today.ToString("yyyyMMdd") + ".jpg");

                        string directoryPath = Path.GetDirectoryName(path);

                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        File.Copy(Add_PictureBox.ImageLocation, path, true);

                        var newBook = new Bookk
                        {
                            Book_Title = BookTitle.Text.Trim(),
                            Author = Author.Text.Trim(),
                            Published_Date = PublishedDate.Value,
                            Book_Status = Status.Text.Trim(),
                            Image = path,
                            Date_Insert = today
                        };

                        db.Bookks.InsertOnSubmit(newBook);
                        db.SubmitChanges();

                        BookAdded?.Invoke(new Bookk
                        {
                            Book_Title = BookTitle.Text.Trim(),
                            Author = Author.Text.Trim(),
                            Published_Date = PublishedDate.Value,
                            Book_Status = Status.Text.Trim(),
                            Image = path
                        });

                        DisplayBook();
                        MessageBox.Show("Book Successfully Added",
                            "Information Message", MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                BookID = (int)row.Cells[0].Value;
                BookTitle.Text = row.Cells[1].Value.ToString();
                Author.Text = row.Cells[2].Value.ToString();
                PublishedDate.Text = row.Cells[3].Value.ToString();

                string imagePath = row.Cells[7].Value.ToString();

                if (!string.IsNullOrEmpty(imagePath))
                {
                    try
                    {
                        if (File.Exists(imagePath))
                        {
                            Add_PictureBox.Image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            MessageBox.Show($"Image file not found at path: {imagePath}", "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Add_PictureBox.Image = null; // Or set a default image
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Status.Text = row.Cells[4].Value.ToString();
            }
        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            if (Add_PictureBox.Image == null ||
               BookTitle.Text == "" || Author.Text == "" ||
               PublishedDate.Value == null || Status.Text == "" || Add_PictureBox.Image == null)
            {
                MessageBox.Show("Please select a book first", "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var db = new LibraryDataContext())
                {
                    DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Book ID: " + BookID + " ?",
                        "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (check == DialogResult.Yes)
                    {
                        try
                        {
                            var bookToUpdate = db.Bookks.SingleOrDefault(book => book.BookID == BookID);

                            if (bookToUpdate != null)
                            {
                                DateTime today = DateTime.Today;

                                bookToUpdate.Book_Title = BookTitle.Text.Trim();
                                bookToUpdate.Author = Author.Text.Trim();
                                bookToUpdate.Published_Date = PublishedDate.Value;
                                bookToUpdate.Book_Status = Status.Text.Trim();
                                bookToUpdate.Date_Update = today;

                                db.SubmitChanges();
                                DisplayBook();
                                MessageBox.Show("Book Successfully Updated", "Information Message",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
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
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (Add_PictureBox.Image == null ||
                BookTitle.Text == "" || Author.Text == "" ||
                PublishedDate.Value == null || Status.Text == "" || Add_PictureBox.Image == null)
            {
                MessageBox.Show("Please select a book first", "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var db = new LibraryDataContext())
                {
                    DialogResult check = MessageBox.Show("Are you sure you want to DELETE Book ID: " + BookID + " ?",
                        "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (check == DialogResult.Yes)
                    {
                        try
                        {
                            var bookToDelete = db.Bookks.SingleOrDefault(book => book.BookID == BookID);

                            if (bookToDelete != null)
                            {
                                db.Bookks.DeleteOnSubmit(bookToDelete);
                                db.SubmitChanges();
                                DisplayBook();
                                MessageBox.Show("Book Successfully Deleted", 
                                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, 
                                "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cancelled.", "Information Message", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void openFileForBookCoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imagePath = "";

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    Add_PictureBox.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
