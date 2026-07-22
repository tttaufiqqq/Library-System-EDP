using System;
using System.Diagnostics;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class BorrowerFines
    {
        private readonly FinePaymentService _paymentService = new FinePaymentService();

        private void buttonPay_Click(object sender, EventArgs e)
        {
            int? fineId = SelectedFineId();
            if (fineId == null)
            {
                MessageBox.Show("Select a fine first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Re-read from the ledger rather than trusting the grid row -
            // the amount and status shown here could be a moment stale.
            var fine = _fineService.GetById(fineId.Value);
            if (fine == null || fine.Status != "Unpaid")
            {
                MessageBox.Show("This fine has already been settled.", "No Fine Due", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFines(_email);
                return;
            }

            var confirm = MessageBox.Show(
                $"Pay RM {fine.Amount:F2} for '{fine.Book_Title}' via FPX online banking?",
                "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            string billCode;
            try
            {
                LoadingOverlay.Show(this);
                billCode = _paymentService.StartPayment(fineId.Value);
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Could not start payment", ex);
                return;
            }
            finally
            {
                LoadingOverlay.Hide(this);
            }

            if (billCode == null)
            {
                MessageBox.Show("Could not start the payment. Please try again later.",
                    "Payment Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Process.Start(_paymentService.BillUrl(billCode));
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Could not open your browser", ex);
                return;
            }

            using (var dialog = new PaymentWaitDialog(_paymentService, billCode, fine.Amount))
            {
                DialogResult result = dialog.ShowDialog(this);
                switch (result)
                {
                    case DialogResult.OK:
                        MessageBox.Show("Payment received. Thank you!", "Payment Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case DialogResult.Abort:
                        MessageBox.Show("The payment was not successful. You can try again.",
                            "Payment Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    default: // Cancel or Retry (timeout)
                        MessageBox.Show(
                            "Payment not confirmed. If you completed it in the browser, reopen My Fines in a few minutes and press Pay again to re-check.",
                            "Payment Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }

            LoadFines(_email);
        }
    }
}
