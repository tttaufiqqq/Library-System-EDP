using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class BorrowerRequests : UserControl
    {
        private readonly RequestService _requestService = new RequestService();

        public BorrowerRequests()
        {
            InitializeComponent();
        }

        public void LoadRequests(string email)
        {
            if (InvokeRequired) { Invoke((MethodInvoker)(() => LoadRequests(email))); return; }

            try
            {
                var requests = _requestService.GetRequestsByEmail(email)
                    .Select(r => new
                    {
                        r.Book_Title,
                        r.Author,
                        r.Requested_Date,
                        r.Return_Date,
                        r.Status,
                        r.Decided_Date
                    }).ToList();

                dataGridView1.DataSource = requests;
                EmptyStateHelper.Toggle(dataGridView1, requests.Count == 0, "You have no book requests.", Color.White);
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading your requests", ex);
            }
        }
    }
}
