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
            

            if (accountDetails.CanHandle(paymentType))
            {
            
                var clientDetails = JObject.FromObject(accountDetails);
                clientDetails.Add("Amount", amount);
                var payment = new FakeBitCoinPaymentServer();
                var res = payment.Process(clientDetails.ToString());
                    
                
                if (res.Contains("Success"))
                {
                    successfulPayment = true;
                    return successfulPayment;
                }
            }

            if (accountDetails.CanHandle(paymentType))
            {
                
                var payment = new FakeDirectDebitPaymentServer("ROTE-0001UK");
                
               var clientDetails = accountDetails.AcountDetails(accountDetails);


                var res = payment.MakePayment(clientDetails["CardHolder"] ,clientDetails["CardNumber"], clientDetails["Cvv"],(double) amount);

                if (!string.IsNullOrEmpty(res))
                {
                    successfulPayment = true;
                    return successfulPayment;
                }
            }
         
            

        
            

            //TODO: Make the payment


            return successfulPayment;
        }
    }
}