using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class IssuedBooks : UserControl
    {
        private readonly IssueService _issueService = new IssueService();

        public IssuedBooks()
        {
            InitializeComponent();
            GridStyleHelper.Apply(dataGridView1);
            ArrowKeyNavigationHelper.Enable(this);
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            displayBookIssueData();
            toolStripStatusLabel1.Text = "";
        }

        public void refreshData()
        {
            if (InvokeRequired) { Invoke((MethodInvoker)refreshData); return; }
            displayBookIssueData();
            clearFields();
        }

        public void displayBookIssueData()
        {
            try
            {
                var issues = _issueService.GetIssueDisplayData();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = issues;
                dataGridView1.Refresh();
                EmptyStateHelper.Toggle(dataGridView1, issues.Count == 0, "No issued books found.", Color.Black);
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
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
