using System.Linq;
using Newtonsoft.Json.Linq;
using RicsOnlineTurnipEmporium.Domain;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium
{
    public class Checkout
    {
        public bool MakePayment(PaymentType paymentType, decimal amount, IAccountDetails accountDetails)
        {
            var successfulPayment = false;


            var payment = new FakeBitCoinPaymentServer();
            JObject accountants = (JObject) JToken.FromObject(accountDetails);
           accountants.Add("Amount", amount);
           var res = payment.Process(accountants.ToString());


            //var requestData = JObject.Parse(res);

            
            if (res.Contains("Success"))
            {
                successfulPayment = true;
            }
            

            //TODO: Make the payment
            //call the right sver 

            return successfulPayment;
        }
    }
}