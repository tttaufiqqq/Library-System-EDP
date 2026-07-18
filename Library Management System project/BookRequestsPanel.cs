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
            GridStyleHelper.Apply(dataGridView1);
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
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading requests", ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var request = dataGridView1.Rows[e.RowIndex].DataBoundItem as BookRequest;
            if (request == null) return;

            using (var dialog = new RequestDetailsDialog(request, _staffUsername))
            {
                dialog.ShowDialog();
                if (dialog.ResultMessage != null) toolStripStatusLabel1.Text = dialog.ResultMessage;
                DisplayRequests();
            }
        }
    }
}
