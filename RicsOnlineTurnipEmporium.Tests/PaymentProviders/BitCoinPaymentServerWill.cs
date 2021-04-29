using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium.Tests.PaymentProviders
{
    [TestFixture]
    public class BitCoinPaymentServerWill
    {
        [Test]
        public void ReturnSuccessResultForSuccessfulPayment()
        {
            var paymentProvider = new FakeBitCoinPaymentServer();
            var result =
                paymentProvider
                    .Process("{\"ReceivingWalletId\":\"93098DDA-3873-484A-B4A4-19C25438A71A\", \"PaymentWalletId\":\"31ACD47B-60D5-4FA5-9213-D7A02C55E172\", \"AuthCode\":\"78736511-480E-4A3C-8F07-CE4BED6E0387\", \"Amount\":0.000012}");

            Assert.That((string) JObject.Parse(result).SelectToken("Status"), Is.EqualTo("Success"));
        }

        [Test]
        public void ReturnFailureResultForLargePayment()
        {
            var paymentProvider = new FakeBitCoinPaymentServer();
            var result =
                paymentProvider
                    .Process("{\"ReceivingWalletId\":\"93098DDA-3873-484A-B4A4-19C25438A71A\", \"PaymentWalletId\":\"31ACD47B-60D5-4FA5-9213-D7A02C55E172\", \"AuthCode\":\"78736511-480E-4A3C-8F07-CE4BED6E0387\", \"Amount\":1.100012}");

            var response = JObject.Parse(result);
            Assert.That((string) response.SelectToken("Status"), Is.EqualTo("Failure"));
            Assert.That((string) response.SelectToken("ErrorMessage"), Is.EqualTo("Transaction to large"));
        }

        [Test]
        public void ReturnFailureResultForSamePaymentAndReceivingWallet()
        {
            var paymentProvider = new FakeBitCoinPaymentServer();
            var result =
                paymentProvider
                    .Process("{\"ReceivingWalletId\":\"93098DDA-3873-484A-B4A4-19C25438A71A\", \"PaymentWalletId\":\"93098DDA-3873-484A-B4A4-19C25438A71A\", \"AuthCode\":\"78736511-480E-4A3C-8F07-CE4BED6E0387\", \"Amount\":0.100012}");

            var response = JObject.Parse(result);
            Assert.That((string) response.SelectToken("Status"), Is.EqualTo("Failure"));
            Assert.That((string) response.SelectToken("ErrorMessage"), Is.EqualTo("Receiving and Payment wallets are the same"));
        }

        [Test]
        public void ReturnFailureResultForMissingAuthentication()
        {
            var paymentProvider = new FakeBitCoinPaymentServer();
            var result =
                paymentProvider
                    .Process("{\"ReceivingWalletId\":\"93098DDA-3873-484A-B4A4-19C25438A71A\", \"PaymentWalletId\":\"31ACD47B-60D5-4FA5-9213-D7A02C55E172\", \"AuthCode\":\"\", \"Amount\":0.100012}");

            var response = JObject.Parse(result);
            Assert.That((string) response.SelectToken("Status"), Is.EqualTo("Failure"));
            Assert.That((string) response.SelectToken("ErrorMessage"), Is.EqualTo("Invalid AuthCode"));
        }
    }
}