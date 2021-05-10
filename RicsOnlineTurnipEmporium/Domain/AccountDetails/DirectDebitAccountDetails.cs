using System.Collections.Generic;

namespace RicsOnlineTurnipEmporium.Domain.AccountDetails
{
    public class DirectDebitAccountDetails : IAccountDetails
    {
        public DirectDebitAccountDetails(string cardHolder, string cardNumber, string cvv)
        {
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            Cvv = cvv;
        }
        private string CardHolder { get; }
        private string CardNumber { get; }
        private string Cvv { get; }
        public bool CanHandle(PaymentType paymentType) { return paymentType == PaymentType.DebitCard; }
        public Dictionary<string, string> AccountDetails(IAccountDetails accountDetails)
        {
          return new()
            {
                {"CardHolder", CardHolder},
                {"CardNumber", CardNumber},
                {"Cvv", Cvv}
            };
            
        }
    }
}