using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class ReturnBooks : UserControl
    {
        private readonly IssueService _issueService = new IssueService();

        public ReturnBooks()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            DisplayPendingReturns();
            toolStripStatusLabel1.Text = "";
        }

        public void refreshData()
        {
            if (InvokeRequired) { Invoke((MethodInvoker)refreshData); return; }
            DisplayPendingReturns();
        }

        private void DisplayPendingReturns()
        {
            try
            {
                var issues = _issueService.GetPendingReturnRequests();
                dataGridView1.DataSource = issues;
                EmptyStateHelper.Toggle(dataGridView1, issues.Count == 0, "No return requests pending.", Color.Black);
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading return requests", ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var issue = dataGridView1.Rows[e.RowIndex].DataBoundItem as IssuesBook;
            if (issue == null) return;

            using (var dialog = new ReturnConfirmDialog(issue))
            {
                dialog.ShowDialog();
                if (dialog.Confirmed)
                {
                    toolStripStatusLabel1.Text = "Issue " + issue.IssueID + " marked as returned.";
                    DisplayPendingReturns();
                }
            }
        }
    }
}
