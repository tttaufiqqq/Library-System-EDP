namespace Library_Management_System_project.Services
{
    // Contract for a hosted-payment-page gateway. Mirrors the
    // IImageStorageService/ImageStorageService shape: one interface, one real
    // implementation (ToyyibPayService), so the borrower payment flow can be
    // exercised without a live sandbox connection.
    public interface IPaymentGateway
    {
        // Returns the bill code to redirect to, or null if the gateway could
        // not create the bill (network failure, bad response) - callers must
        // treat null as "payment could not be started", never as success.
        string CreateBill(BillRequest request);

        string BillUrl(string billCode);

        // Fails closed: any HTTP error, timeout, or unparsable response
        // returns PaymentStatus.Unknown, never Success.
        PaymentStatus GetBillStatus(string billCode);
    }
}
