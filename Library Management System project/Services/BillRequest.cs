namespace Library_Management_System_project.Services
{
    // What CreateBill needs to know about the fine being paid - never the
    // amount alone, so the gateway wrapper cannot be called with a
    // caller-supplied number that didn't come from the ledger.
    public class BillRequest
    {
        public string BillName { get; set; }
        public string BillDescription { get; set; }
        public decimal AmountRinggit { get; set; }
        public string ReferenceNo { get; set; }
        public string PayerName { get; set; }
        public string PayerEmail { get; set; }
        public string PayerPhone { get; set; }
    }
}
