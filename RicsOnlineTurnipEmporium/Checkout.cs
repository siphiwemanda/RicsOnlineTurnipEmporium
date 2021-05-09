using System.Linq;
using Newtonsoft.Json.Linq;
using RicsOnlineTurnipEmporium.Domain;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.Factory;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium
{
    public class Checkout
    {
        public bool MakePayment(PaymentType paymentType, decimal amount, IAccountDetails accountDetails)
        {
           
            var makePayment = FakeServerProvider.CallServer(paymentType, amount, accountDetails);



            //TODO: Make the payment
            return makePayment;


        }
    }
}