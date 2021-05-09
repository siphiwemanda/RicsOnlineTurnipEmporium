using System;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium.Domain.Factory
{
    public class FakeServerProvider
    {
        public static IFakeServer CreateServer(PaymentType paymentType)
        {
            IFakeServer fakeserver = paymentType switch
            {
                PaymentType.BitCoin => new FakeBitCoinPaymentServer(),
                PaymentType.DebitCard => new FakeDirectDebitPaymentServer("ROTE-0001UK"),
                PaymentType.PayPal => new FakePayPalPaymentServer(),
                _ => throw new ArgumentOutOfRangeException(nameof(paymentType), paymentType, null)
            };

            return fakeserver;
        }

    }
}