namespace RicsOnlineTurnipEmporium.Domain.FakePaymentServers
{
    public class PayPalTransactionResult
    {
        public PayPalTransactionResult(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
        public bool Success { get; }
        public string ErrorMessage { get; }
    }
}
