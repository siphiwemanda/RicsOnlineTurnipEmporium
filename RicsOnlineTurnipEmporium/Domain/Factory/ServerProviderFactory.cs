using System;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.PaymentProviders;

namespace RicsOnlineTurnipEmporium.Domain.Factory
{
    public class ServerProviderFactory
    {
        
        public static IPaymentProviders CreatePaymentProvider(PaymentType paymentType, IAccountDetails account)
        {
            IPaymentProviders paymentProvider = paymentType switch
            {
                PaymentType.BitCoin when account.CanHandle(paymentType) => new BitCoinPaymentProvider(),
                PaymentType.DebitCard when account.CanHandle(paymentType) => new DirectDebitPaymentProvider(),
                PaymentType.PayPal when account.CanHandle(paymentType) => new PayPalPaymentProvider(),
                _ => throw new Exception("blah")
            };

            return paymentProvider;
        }

    }
}