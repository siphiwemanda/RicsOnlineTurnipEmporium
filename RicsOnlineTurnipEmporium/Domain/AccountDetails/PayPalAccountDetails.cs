namespace RicsOnlineTurnipEmporium.Domain.AccountDetails
{
    public class PayPalAccountDetails : IAccountDetails
    {
        public PayPalAccountDetails(string authenticationToken) { AuthenticationToken = authenticationToken; }
        public string AuthenticationToken { get; }
        public bool CanHandle(PaymentType paymentType) { return paymentType == PaymentType.PayPal; }
    }
}