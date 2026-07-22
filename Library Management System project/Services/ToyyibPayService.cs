using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Library_Management_System_project.Services
{
    // Wraps the ToyyibPay sandbox (dev.toyyibpay.com) hosted-payment-page API.
    // billPaymentChannel=0 restricts every bill to FPX online banking only -
    // that single parameter is what keeps card entry out of this codebase
    // entirely; there is no card form anywhere for it to need protecting.
    //
    // A WinForms desktop app has no web server to receive billReturnUrl /
    // billCallbackUrl, so both are pointed at the gateway's own domain and are
    // never relied on for anything. The only source of truth for "did this
    // bill get paid" is GetBillStatus, polled by PaymentWaitDialog. See
    // docs/fine-and-payment.md for the full rationale.
    public class ToyyibPayService : IPaymentGateway
    {
        private readonly string _baseUrl;
        private readonly string _categoryCode;

        // Built lazily, not at construction time - constructing this from the
        // WinForms designer (e.g. BorrowerFines) must not require a reachable
        // endpoint. Mirrors ImageStorageService's lazy Client property.
        private static readonly HttpClient _http = new HttpClient();
        private readonly JavaScriptSerializer _json = new JavaScriptSerializer();

        public ToyyibPayService()
        {
            _baseUrl = (ConfigurationManager.AppSettings["ToyyibPayBaseUrl"] ?? "https://dev.toyyibpay.com").TrimEnd('/');
            _categoryCode = ConfigurationManager.AppSettings["ToyyibPayCategoryCode"];
        }

        private string SecretKey
        {
            get
            {
                string key = ConfigurationManager.AppSettings["ToyyibPaySecretKey"];
                if (string.IsNullOrWhiteSpace(key))
                    throw new InvalidOperationException("ToyyibPaySecretKey is not configured in App.config.");
                return key;
            }
        }

        public string BillUrl(string billCode) => $"{_baseUrl}/{billCode}";

        public string CreateBill(BillRequest request)
        {
            try
            {
                var fields = new Dictionary<string, string>
                {
                    ["userSecretKey"] = SecretKey,
                    ["categoryCode"] = _categoryCode,
                    ["billName"] = Truncate(request.BillName, 30),
                    ["billDescription"] = Truncate(request.BillDescription, 100),
                    ["billPriceSetting"] = "1",
                    ["billPayorInfo"] = "1",
                    ["billAmount"] = ((int)(request.AmountRinggit * 100)).ToString(),
                    ["billReturnUrl"] = _baseUrl,
                    ["billCallbackUrl"] = _baseUrl,
                    ["billExternalReferenceNo"] = request.ReferenceNo,
                    ["billTo"] = request.PayerName,
                    ["billEmail"] = request.PayerEmail,
                    ["billPhone"] = request.PayerPhone,
                    ["billSplitPayment"] = "0",
                    ["billPaymentChannel"] = "0",
                    ["billChargeToCustomer"] = "1",
                    ["billContentEmail"] = "Thank you for settling your library fine."
                };

                var response = Task.Run(() => _http.PostAsync(
                    $"{_baseUrl}/index.php/api/createBill",
                    new FormUrlEncodedContent(fields))).GetAwaiter().GetResult();

                string body = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                if (!response.IsSuccessStatusCode) { AppLogger.LogError("ToyyibPay createBill", new Exception(body)); return null; }

                var results = _json.Deserialize<List<Dictionary<string, object>>>(body);
                string billCode = GetField(results?.FirstOrDefault(), "BillCode");
                return string.IsNullOrEmpty(billCode) ? null : billCode;
            }
            catch (Exception ex)
            {
                AppLogger.LogError("ToyyibPay createBill", ex);
                return null;
            }
        }

        public PaymentStatus GetBillStatus(string billCode)
        {
            try
            {
                var fields = new Dictionary<string, string>
                {
                    ["billCode"] = billCode,
                    ["userSecretKey"] = SecretKey
                };

                var response = Task.Run(() => _http.PostAsync(
                    $"{_baseUrl}/index.php/api/getBillTransactions",
                    new FormUrlEncodedContent(fields))).GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode) return PaymentStatus.Unknown;

                string body = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();

                // Before any transaction attempt exists on a bill, ToyyibPay
                // replies with the plain-text "No data found!" instead of a
                // JSON array - the borrower simply hasn't opened/paid the
                // bill page yet. This is the ordinary "still waiting" state,
                // not a malformed response, so it must not be treated as an
                // exception-worthy failure on every single poll tick.
                if (!body.TrimStart().StartsWith("[")) return PaymentStatus.Pending;

                var results = _json.Deserialize<List<Dictionary<string, object>>>(body);
                string rawStatus = GetField(results?.FirstOrDefault(), "billpaymentStatus");

                switch (rawStatus)
                {
                    case "1": return PaymentStatus.Success;
                    case "2": return PaymentStatus.Pending;
                    case "3": return PaymentStatus.Failed;
                    default: return PaymentStatus.Unknown;
                }
            }
            catch (Exception ex)
            {
                // Any network blip, timeout, or malformed response fails
                // closed - it must never be mistaken for a successful payment.
                AppLogger.LogError("ToyyibPay getBillTransactions", ex);
                return PaymentStatus.Unknown;
            }
        }

        private static string Truncate(string value, int maxLength) =>
            string.IsNullOrEmpty(value) || value.Length <= maxLength ? value : value.Substring(0, maxLength);

        // Dictionary<TKey,TValue>.GetValueOrDefault is not available on
        // .NET Framework 4.7.2 (it's a .NET Core / Standard 2.1 addition).
        private static string GetField(Dictionary<string, object> row, string key)
        {
            object value;
            return row != null && row.TryGetValue(key, out value) ? value as string : null;
        }
    }
}
