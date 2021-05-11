using System;
using Newtonsoft.Json.Linq;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium.Domain.PaymentProviders
{
    public class BitCoinPaymentProvider : IPaymentProviders
    {
        public bool MakePayment(double amount, IAccountDetails accountDetails)
        {
            var bitCoinPaymentServer = new FakeBitCoinPaymentServer();
            var clientDetails = JObject.FromObject(accountDetails);
            clientDetails.Add("Amount", amount);
            var res = bitCoinPaymentServer.Process(clientDetails.ToString());
            return res.Contains("Success");
        }
    }
}