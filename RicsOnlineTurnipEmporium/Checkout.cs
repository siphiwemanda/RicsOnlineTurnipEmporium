using RicsOnlineTurnipEmporium.Domain;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.Factory;

namespace RicsOnlineTurnipEmporium
{
    public class Checkout
    {
        public bool MakePayment(PaymentType paymentType, decimal amount, IAccountDetails accountDetails)
        {
            var server = FakeServerProvider.CreateServer(paymentType, accountDetails);
            var paymentResult = server.CallServer((double) amount, accountDetails);

            return paymentResult;
        }
    }
}