using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    // Read-only fines report for staff. Payment is borrower-only (see
    // BorrowerFines.cs / BorrowerFines.Payment.cs) - this screen has no card
    // fields, no cash option, and no Pay button, on purpose.
    public partial class Fine : UserControl
    {
        private readonly FineService _fineService = new FineService();

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
                var fines = _fineService.GetReport()
                    .Select(f => new
                    {
                        Borrower = f.Full_Name,
                        f.Book_Title,
                        f.Overdue_Days,
                        f.Amount,
                        f.Status,
                        f.Assessed_Date,
                        f.Paid_Date
                    }).ToList();

                dataGridViewFines.DataSource = fines;
                EmptyStateHelper.Toggle(dataGridViewFines, fines.Count == 0, "No fines recorded.", Color.Black);

                decimal total = fines.Where(f => f.Status == "Unpaid").Sum(f => f.Amount);
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

        private void buttonCalculate_Click(object sender, EventArgs e) => LoadReport();
    }
}
