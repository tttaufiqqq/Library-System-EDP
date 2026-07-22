namespace Library_Management_System_project.Services
{
    // Mirrors ToyyibPay's billpaymentStatus: '1'=Success, '2'=Pending, '3'=Failed.
    // Unknown is the fail-closed default for any HTTP error, timeout, or
    // malformed response - it must never be treated as Success.
    public enum PaymentStatus
    {
        Unknown,
        Pending,
        Success,
        Failed
    }
}
