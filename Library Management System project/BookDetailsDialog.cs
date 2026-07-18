using System;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class BookDetailsDialog : Form
    {
        private readonly Bookk _book;
        private readonly string _email;
        private readonly string _fullName;

        public BookDetailsDialog(Bookk book, string email, string fullName)
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Text = "Book Details";

            _book = book;
            _email = email;
            _fullName = fullName;

            labelTitle.Text = book.Book_Title;
            labelAuthor.Text = "Author: " + (book.Author ?? "Unknown");
            labelPublished.Text = "Published: " + (book.Published_Date.HasValue ? DateHelper.Format(book.Published_Date.Value) : "Unknown");
            labelStatus.Text = "Status: " + book.Book_Status;
            pictureBoxCover.Image = new BookService().LoadBookImage(book.Image);
            buttonBorrow.Enabled = book.Book_Status == "Available";
        }

        private void buttonBorrow_Click(object sender, EventArgs e)
        {
            using (var dialog = new RequestBookDialog(_book.Book_Title, _book.Author))
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;

                var check = BorrowingPolicy.Check(_email, _book.BookID, _book.Book_Title, _book.Book_Status);
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
                        BookID = _book.BookID,
                        Book_Title = _book.Book_Title,
                        Author = _book.Author,
                        Requested_Date = DateTime.Today,
                        Return_Date = dialog.ReturnDate,
                        Status = "Pending"
                    });

                    MessageBox.Show("Request submitted, pending staff approval.",
                        "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    ErrorPresenter.Show("Error submitting request", ex);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
