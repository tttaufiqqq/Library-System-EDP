using System;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    // Modal "waiting for payment" dialog. Polls the gateway on a UI-thread
    // Timer rather than async/await or BackgroundWorker - every other service
    // in this app bridges async work synchronously (see ImageStorageService),
    // and a Timer needs no thread marshalling to update labelStatus.
    //
    // This dialog is the ONLY place a fine is ever settled from the payment
    // flow: it never trusts anything but FinePaymentService.CheckStatus's
    // return value, which itself fails closed on any gateway error.
    public partial class PaymentWaitDialog : Form
    {
        private const int PollIntervalMs = 4000;
        private const int MaxPolls = 75; // 75 * 4s = 5 minutes

        private readonly FinePaymentService _paymentService;
        private readonly string _billCode;
        private int _pollCount;
        private bool _polling; // re-entrancy guard: a slow HTTP call must not overlap the next tick

        public PaymentWaitDialog(FinePaymentService paymentService, string billCode, decimal amount)
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            _paymentService = paymentService;
            _billCode = billCode;
            labelAmount.Text = $"Amount: RM {amount:F2}";
        }

        private void PaymentWaitDialog_Load(object sender, EventArgs e)
        {
            timerPoll.Interval = PollIntervalMs;
            timerPoll.Start();
        }

        private void timerPoll_Tick(object sender, EventArgs e)
        {
            if (_polling) return;
            _polling = true;
            try
            {
                _pollCount++;
                labelStatus.Text = $"Checking payment status... (attempt {_pollCount})";

                PaymentStatus status = _paymentService.CheckStatus(_billCode);
                switch (status)
                {
                    case PaymentStatus.Success:
                        timerPoll.Stop();
                        _paymentService.Settle(_billCode);
                        DialogResult = DialogResult.OK;
                        Close();
                        return;

                    case PaymentStatus.Failed:
                        timerPoll.Stop();
                        _paymentService.MarkFailed(_billCode);
                        DialogResult = DialogResult.Abort;
                        Close();
                        return;

                    default: // Pending or Unknown - fail closed, keep waiting
                        if (_pollCount >= MaxPolls)
                        {
                            timerPoll.Stop();
                            DialogResult = DialogResult.Retry;
                            Close();
                        }
                        return;
                }
            }
            finally
            {
                _polling = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            timerPoll.Stop();
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
