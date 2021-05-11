using System;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium.Domain.PaymentProviders
{
    public class DirectDebitPaymentProvider : IPaymentProviders
    {
        public bool MakePayment(double amount, IAccountDetails accountDetails)
        {
            var directDebitPaymentServer = new FakeDirectDebitPaymentServer("ROTE-0001UK");
            if (accountDetails is not DirectDebitAccountDetails directDebit)
            {
                throw new Exception("Account type is not correct");
            }

            var res = directDebitPaymentServer.MakePayment(directDebit.CardHolder, directDebit.CardNumber,
                directDebit.Cvv, amount);

            return !string.IsNullOrEmpty(res);
        }
    }
}