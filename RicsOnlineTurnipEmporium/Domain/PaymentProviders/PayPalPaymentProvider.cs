using System;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium.Domain.PaymentProviders
{
    public class PayPalPaymentProvider : IPaymentProviders
    {
        public bool MakePayment(double amount, IAccountDetails accountDetails)
        {
            var payPalPaymentServer = new FakePayPalPaymentServer();
            if (accountDetails is not PayPalAccountDetails payPalAccountDetails)
            {
                throw new Exception("test");
            }
            var transactionKey = payPalPaymentServer.BeginTransaction("C6BE96CA-C7D4-4D36-9852-DF1B44046022");
            payPalPaymentServer.SubmitPayment(transactionKey, payPalAccountDetails.AuthenticationToken, amount);
            var res = payPalPaymentServer.CommitTransaction(transactionKey);
            return res.Success;
        }
    }
}