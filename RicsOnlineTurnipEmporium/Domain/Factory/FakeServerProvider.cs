using System;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium.Domain.Factory
{
    public class FakeServerProvider
    {
        public static IFakeServer CreateServer(PaymentType paymentType, IAccountDetails account)
        {
            IFakeServer fakeServer = paymentType switch
            {
                PaymentType.BitCoin when account.CanHandle(paymentType) => new FakeBitCoinPaymentServer(),
                PaymentType.PayPal when account.CanHandle(paymentType) => new FakePayPalPaymentServer(),
                PaymentType.DebitCard when account.CanHandle(paymentType) => new FakeDirectDebitPaymentServer("ROTE-0001UK"),
                _ => throw new ArgumentOutOfRangeException(nameof(paymentType), paymentType, null)
            };

            return fakeServer;
        }

    }
}