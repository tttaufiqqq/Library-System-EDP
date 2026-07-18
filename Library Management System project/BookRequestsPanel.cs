using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class BookRequestsPanel : UserControl
    {
        private readonly RequestService _requestService = new RequestService();
        private string _staffUsername;

        public BookRequestsPanel()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            toolStripStatusLabel1.Text = "";
            DisplayRequests();
        }

        public void SetStaffUsername(string username)
        {
            _staffUsername = username;
        }

        public void RefreshData()
        {
            if (InvokeRequired) { Invoke((MethodInvoker)RefreshData); return; }
            DisplayRequests();
        }

        private void DisplayRequests()
        {
            try
            {
                var requests = _requestService.GetPendingRequests();
                dataGridView1.DataSource = requests;
                EmptyStateHelper.Toggle(dataGridView1, requests.Count == 0, "No pending requests.", Color.Black);
                UpdateButtonState();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading requests", ex);
            }
        }

        private BookRequest GetSelectedRequest()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return dataGridView1.SelectedRows[0].DataBoundItem as BookRequest;
        }

        private void UpdateButtonState()
        {
            bool hasSelection = GetSelectedRequest() != null;
            buttonApprove.Enabled = hasSelection;
            buttonReject.Enabled = hasSelection;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DisplayRequests();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void buttonApprove_Click(object sender, EventArgs e)
        {
            var request = GetSelectedRequest();
            if (request == null) return;

            var result = _requestService.Approve(request.RequestID, _staffUsername);
            toolStripStatusLabel1.Text = result.Message;
            MessageBox.Show(result.Message, "Information Message",
                MessageBoxButtons.OK, result.Approved ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            DisplayRequests();
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            var request = GetSelectedRequest();
            if (request == null) return;

            if (MessageBox.Show("Are you sure you want to REJECT request " + request.RequestID + " ?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            bool rejected = _requestService.Reject(request.RequestID, _staffUsername);
            toolStripStatusLabel1.Text = rejected
                ? $"Request {request.RequestID} rejected."
                : "Request not found or already decided.";
            DisplayRequests();
        }
    }
}
