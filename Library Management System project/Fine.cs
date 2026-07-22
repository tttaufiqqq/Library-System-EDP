using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    // Read-only fines report for staff. Payment is borrower-only (see
    // BorrowerFines.cs / BorrowerFines.Payment.cs) - this screen has no card
    // fields, no cash option, and no Pay button, on purpose. Clicking a row
    // opens FineDetailsDialog, a read-only view of that one fine.
    public partial class Fine : UserControl
    {
        private readonly FineService _fineService = new FineService();
        private List<FineRecord> _report = new List<FineRecord>();

        public Fine()
        {
            InitializeComponent();
        }

        private void fine_Load(object sender, EventArgs e)
        {
            GridStyleHelper.Apply(dataGridViewFines);
        }

        public void RefreshData() => LoadReport();

        private void LoadReport()
        {
            try
            {
                LoadingOverlay.Show(this);
                _report = _fineService.GetReport();
                var display = _report
                    .Select(f => new
                    {
                        f.FineID,
                        Borrower = f.Full_Name,
                        f.Book_Title,
                        f.Overdue_Days,
                        f.Amount,
                        f.Status,
                        f.Assessed_Date,
                        f.Paid_Date
                    }).ToList();

                dataGridViewFines.DataSource = display;
                if (dataGridViewFines.Columns["FineID"] != null)
                    dataGridViewFines.Columns["FineID"].Visible = false;
                EmptyStateHelper.Toggle(dataGridViewFines, display.Count == 0, "No fines recorded.", Color.Black);

                decimal total = _report.Where(f => f.Status == "Unpaid").Sum(f => f.Amount);
                labelTotalOutstanding.Text = $"Total outstanding: RM {total:F2}";
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading fines report", ex);
            }
            finally
            {
                LoadingOverlay.Hide(this);
            }
        }

        private void dataGridViewFines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var fineIdValue = dataGridViewFines.Rows[e.RowIndex].Cells["FineID"].Value;
            if (!(fineIdValue is int fineId)) return;

            var fine = _report.FirstOrDefault(f => f.FineID == fineId);
            if (fine == null) return;

            using (var dialog = new FineDetailsDialog(fine))
            {
                dialog.ShowDialog();
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e) => LoadReport();
    }
}
