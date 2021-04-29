using System;

namespace RicsOnlineTurnipEmporium.Domain.FakePaymentServers
{
    public class FakeDirectDebitPaymentServer
    {
        private readonly string _userId;
        public FakeDirectDebitPaymentServer(string userId)
        {
            _userId = userId;
        }

        public string MakePayment(string cardHolder, string cardNumber, string cvv, double amount)
        {
            if(_userId != "ROTE-0001UK")
                throw new Exception("Invalid account ID");
            return "1234561";
        }
    }
}