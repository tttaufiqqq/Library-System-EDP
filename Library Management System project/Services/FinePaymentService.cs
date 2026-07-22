using System;
using System.Linq;

namespace Library_Management_System_project.Services
{
    // Every payment ATTEMPT is its own dbo.FinePayments row - a fine can be
    // abandoned mid-checkout and retried without losing the audit trail of
    // what was tried before. dbo.Fines only ever flips Unpaid -> Paid once,
    // in Settle, and only for a bill this service itself created.
    public class FinePaymentService : DataService
    {
        private readonly IPaymentGateway _gateway;

        public FinePaymentService() : this(new ToyyibPayService()) { }

        public FinePaymentService(IPaymentGateway gateway)
        {
            _gateway = gateway;
        }

        // Re-reads the fine and takes the amount from the ledger - never from
        // a caller-supplied value, which could be stale or tampered with.
        // Reuses an already-open bill for this fine instead of minting a new
        // one every time Pay is pressed after an abandoned checkout.
        public string StartPayment(int fineId) =>
            WithContext(db =>
            {
                var fine = db.Fines.SingleOrDefault(f => f.FineID == fineId);
                if (fine == null || fine.Status != "Unpaid") return null;

                var existing = db.FinePayments
                    .Where(p => p.FineID == fineId && p.Status == "Pending")
                    .OrderByDescending(p => p.Created_Date)
                    .FirstOrDefault();
                if (existing != null) return existing.Bill_Code;

                string contact = db.IssuesBooks
                    .Where(i => i.IssueID == fine.IssueID)
                    .Select(i => i.Contact)
                    .FirstOrDefault();

                string referenceNo = $"FINE-{fine.FineID}-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

                string billCode = _gateway.CreateBill(new BillRequest
                {
                    BillName = $"Library Fine #{fine.FineID}",
                    BillDescription = $"Overdue fine for '{fine.Book_Title}'",
                    AmountRinggit = fine.Amount,
                    ReferenceNo = referenceNo,
                    PayerName = fine.Full_Name,
                    PayerEmail = fine.Email,
                    PayerPhone = string.IsNullOrWhiteSpace(contact) ? "0000000000" : contact
                });
                if (billCode == null) return null;

                db.FinePayments.InsertOnSubmit(new FinePaymentRecord
                {
                    FineID = fine.FineID,
                    Bill_Code = billCode,
                    Reference_No = referenceNo,
                    Amount = fine.Amount,
                    Channel = "FPX Online Banking",
                    Status = "Pending",
                    Created_Date = DateTime.Now
                });
                db.SubmitChanges();

                return billCode;
            });

        public string BillUrl(string billCode) => _gateway.BillUrl(billCode);

        public PaymentStatus CheckStatus(string billCode) => _gateway.GetBillStatus(billCode);

        // Idempotency guard: settling an already-settled (or already-failed)
        // bill is a no-op, so a repeated poll can never double-settle a fine.
        public bool Settle(string billCode) =>
            WithContext(db =>
            {
                var payment = db.FinePayments.SingleOrDefault(p => p.Bill_Code == billCode);
                if (payment == null || payment.Status != "Pending") return false;

                var fine = db.Fines.SingleOrDefault(f => f.FineID == payment.FineID);
                if (fine == null || fine.Status != "Unpaid") return false;

                payment.Status = "Success";
                payment.Completed_Date = DateTime.Now;
                fine.Status = "Paid";
                fine.Paid_Date = DateTime.Now;

                db.SubmitChanges();
                return true;
            });

        public void MarkFailed(string billCode) =>
            WithContext(db =>
            {
                var payment = db.FinePayments.SingleOrDefault(p => p.Bill_Code == billCode);
                if (payment == null || payment.Status != "Pending") return;

                payment.Status = "Failed";
                payment.Completed_Date = DateTime.Now;
                db.SubmitChanges();
            });
    }
}
