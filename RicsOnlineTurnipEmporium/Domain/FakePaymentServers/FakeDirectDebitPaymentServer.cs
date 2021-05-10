using System;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.Factory;

namespace RicsOnlineTurnipEmporium.Domain.FakePaymentServers
{
    public class FakeDirectDebitPaymentServer : IFakeServer
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
        public bool CallServer(double amount, IAccountDetails accountDetails)
        {
            
            var clientDetails = accountDetails.AccountDetails(accountDetails);

            var res = MakePayment(clientDetails["CardHolder"], clientDetails["CardNumber"],
                clientDetails["Cvv"], (double) amount);

            return !string.IsNullOrEmpty(res);
        }
    }
}