using System;
using Newtonsoft.Json.Linq;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;
using RicsOnlineTurnipEmporium.Domain;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;

namespace RicsOnlineTurnipEmporium.Domain.Factory
{
    public class FakeServerProvider
    {
        public static bool CallServer(PaymentType paymentType, decimal amount, IAccountDetails accountDetails)
        {
            
            if (accountDetails.CanHandle(PaymentType.BitCoin))
            {
                var clientDetails = JObject.FromObject(accountDetails);
                clientDetails.Add("Amount", amount);
                var transaction = new FakeBitCoinPaymentServer();
                var res = transaction.Process(clientDetails.ToString());
                if (res.Contains("Success"))
                {
     
                    return true;

                }
            }
            else if (accountDetails.CanHandle(PaymentType.DebitCard))
            {
                var payment = new FakeDirectDebitPaymentServer("ROTE-0001UK");

                var clientDetails = accountDetails.AcountDetails(accountDetails);


                var res = payment.MakePayment(clientDetails["CardHolder"], clientDetails["CardNumber"],
                    clientDetails["Cvv"], (double) amount);

                if (!string.IsNullOrEmpty(res))
                {
           
                    return true;

                }
            }

            else if (accountDetails.CanHandle(PaymentType.PayPal))
            {
                var payment = new FakePayPalPaymentServer();
                var clietdetails = accountDetails.AcountDetails(accountDetails);
                var transactionID = payment.BeginTransaction("C6BE96CA-C7D4-4D36-9852-DF1B44046022");
                payment.SubmitPayment(transactionID, clietdetails["AuthenticationToken"], (double)amount);
                var res = payment.CommitTransaction(Guid.NewGuid().ToString());
                return res.Success;
                
            }

        
            
            return false;
        }
    }
}