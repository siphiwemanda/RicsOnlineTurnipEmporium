using RicsOnlineTurnipEmporium.Domain;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.Factory;

namespace RicsOnlineTurnipEmporium
{
    public class Checkout
    {
        public bool MakePayment(PaymentType paymentType, decimal amount, IAccountDetails accountDetails)
        {
            var paymentProvider = ServerProviderFactory.CreatePaymentProvider(paymentType, accountDetails);
            var result = paymentProvider.MakePayment((double)amount, accountDetails);

            return result;
        }
    }
}