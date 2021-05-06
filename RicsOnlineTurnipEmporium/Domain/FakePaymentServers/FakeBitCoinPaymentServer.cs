using Newtonsoft.Json.Linq;
using RicsOnlineTurnipEmporium.Domain.Factory;

namespace RicsOnlineTurnipEmporium.Domain.FakePaymentServers
{
    public class FakeBitCoinPaymentServer : IFakeServer
    {
        public string Process(string request)
        {
            var requestData = JObject.Parse(request);

            if ( string.IsNullOrEmpty((string)requestData.SelectToken("AuthCode")))
                return "{\"Status\":\"Failure\", \"ErrorMessage\":\"Invalid AuthCode\"}";
            if ((string)requestData.SelectToken("ReceivingWalletId") == (string)requestData.SelectToken("PaymentWalletId"))
                return "{\"Status\":\"Failure\", \"ErrorMessage\":\"Receiving and Payment wallets are the same\"}";
            if ((decimal) requestData.SelectToken("Amount") > 1)
                return "{\"Status\":\"Failure\", \"ErrorMessage\":\"Transaction to large\"}";
            return "{\"Status\":\"Success\"}";
        }
        
    }
}