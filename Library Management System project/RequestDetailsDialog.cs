using System;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class RequestDetailsDialog : Form
    {
        private readonly BookRequest _request;
        private readonly string _staffUsername;

        public string ResultMessage { get; private set; }

        public RequestDetailsDialog(BookRequest request, string staffUsername)
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Text = "Book Request Details";

            _request = request;
            _staffUsername = staffUsername;

            labelBook.Text = request.Book_Title;
            labelAuthor.Text = "Author: " + (request.Author ?? "Unknown");
            labelBorrower.Text = $"Borrower: {request.Full_Name} ({request.Email})";
            labelContact.Text = "Contact: " + request.Contact;
            labelRequestedDate.Text = "Requested: " + (request.Requested_Date.HasValue ? DateHelper.Format(request.Requested_Date.Value) : "Unknown");
            labelReturnDate.Text = "Return by: " + (request.Return_Date.HasValue ? DateHelper.Format(request.Return_Date.Value) : "Unknown");
            labelStatus.Text = "Status: " + request.Status;

            var book = new BookService().GetBookById(request.BookID);
            pictureBoxCover.Image = new BookService().LoadBookImage(book?.Image);
        }

        private void buttonApprove_Click(object sender, EventArgs e)
        {
            var result = new RequestService().Approve(_request.RequestID, _staffUsername);
            ResultMessage = result.Message;
            MessageBox.Show(result.Message, "Information Message", MessageBoxButtons.OK,
                result.Approved ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            DialogResult = DialogResult.OK;
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to REJECT request " + _request.RequestID + " ?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            bool rejected = new RequestService().Reject(_request.RequestID, _staffUsername);
            ResultMessage = rejected
                ? $"Request {_request.RequestID} rejected."
                : "Request not found or already decided.";
            DialogResult = DialogResult.OK;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
