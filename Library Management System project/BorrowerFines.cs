using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class BorrowerFines : UserControl
    {
        private readonly IssueService _issueService = new IssueService();

        public BorrowerFines()
        {
            InitializeComponent();
            GridStyleHelper.Apply(dataGridView1);
        }

        public void LoadFines(string email)
        {
            if (InvokeRequired) { Invoke((MethodInvoker)(() => LoadFines(email))); return; }

            try
            {
                LoadingOverlay.Show(this);
                var fines = _issueService.GetIssuesByEmail(email)
                    .Select(i => new
                    {
                        i.Book_Title,
                        i.Author,
                        i.Issue_Date,
                        DueDate = i.Return_Date,
                        i.Return_Status,
                        Fine = FineCalculator.ComputeFine(i)
                    }).ToList();

                dataGridView1.DataSource = fines;
                EmptyStateHelper.Toggle(dataGridView1, fines.Count == 0, "You have no fines.", Color.White);
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading your fines", ex);
            }
            finally
            {
                LoadingOverlay.Hide(this);
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a loan first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal fine = (decimal)dataGridView1.CurrentRow.Cells["Fine"].Value;
            if (fine <= 0)
            {
                MessageBox.Show("No fine is due for this loan.", "No Fine",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Your payment is successful.", "Payment Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
