using System;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class RequestBookDialog : Form
    {
        public string Contact { get; private set; }
        public DateTime ReturnDate { get; private set; }

        public RequestBookDialog(string bookTitle, string author)
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Text = "Request Book";

            DateTimePickerStyleHelper.Apply(dateTimePickerReturn);
            labelBookTitleValue.Text = bookTitle;
            labelAuthorValue.Text = author;
            dateTimePickerReturn.Value = DateTime.Today.AddDays(14);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (!InputValidator.IsValidPhone(textBoxContact.Text))
            {
                MessageBox.Show("Please enter a valid contact number.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTimePickerReturn.Value.Date <= DateTime.Today)
            {
                MessageBox.Show("Return date must be in the future.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Contact = textBoxContact.Text.Trim();
            ReturnDate = dateTimePickerReturn.Value.Date;
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
