using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    // Shows only FINALIZED fines (dbo.Fines rows), which only exist once a
    // book has been returned late - see FineService.FinalizeOnReturn. A book that is
    // currently overdue but still out shows its accruing estimate on
    // "My Loans" instead (BorrowerForm.DisplayLoans), not here: a fine only
    // becomes payable, and only appears on this screen, after return.
    public partial class BorrowerFines : UserControl
    {
        private readonly FineService _fineService = new FineService();
        private string _email;

        public BorrowerFines()
        {
            InitializeComponent();
            GridStyleHelper.Apply(dataGridView1);
        }

        public void LoadFines(string email)
        {
            if (InvokeRequired) { Invoke((MethodInvoker)(() => LoadFines(email))); return; }

            _email = email;

            try
            {
                LoadingOverlay.Show(this);
                var fines = _fineService.GetByEmail(email)
                    .OrderByDescending(f => f.Assessed_Date)
                    .Select(f => new
                    {
                        f.FineID,
                        f.Book_Title,
                        f.Overdue_Days,
                        f.Amount,
                        f.Status,
                        f.Assessed_Date,
                        f.Paid_Date
                    }).ToList();

                dataGridView1.DataSource = fines;
                if (dataGridView1.Columns["FineID"] != null) dataGridView1.Columns["FineID"].Visible = false;
                EmptyStateHelper.Toggle(dataGridView1, fines.Count == 0, "You have no fines.", Color.White);

                UpdateTotal();
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

        private void UpdateTotal()
        {
            labelTotal.Text = _email == null
                ? "Total unpaid: RM 0.00"
                : $"Total unpaid: RM {_fineService.GetOutstandingTotal(_email):F2}";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string status = dataGridView1.CurrentRow != null
                ? dataGridView1.CurrentRow.Cells["Status"].Value as string
                : null;
            buttonPay.Enabled = status == "Unpaid";
        }

        private int? SelectedFineId()
        {
            if (dataGridView1.CurrentRow == null) return null;
            return dataGridView1.CurrentRow.Cells["FineID"].Value as int?;
        }
    }
}
