using System;
using NUnit.Framework;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium.Tests.PaymentProviders
{
    [TestFixture]
    public class PayPalPaymentServerWill
    {
        [Test]
        public void ReturnTrueForSuccessfulTransaction()
        {
            const string authenticationToken = "70BD1813-5E24-4EB5-81BC-CB25F4EB8EAD";
            const string accountId = "C6BE96CA-C7D4-4D36-9852-DF1B44046022";

            var paymentProvider = new FakePayPalPaymentServer();
            var transactionKey  = paymentProvider.BeginTransaction(accountId);
            paymentProvider.SubmitPayment(transactionKey, authenticationToken, 15.99);
            var result = paymentProvider.CommitTransaction(transactionKey);
            Assert.That(result.Success, Is.True);
        }

        [Test]
        public void ReturnErrorForForInvalidAccountId()
        {
            const string authenticationToken = "70BD1813-5E24-4EB5-81BC-CB25F4EB8EAD";
            const string accountId = "00000000-C7D4-4D36-9852-DF1B44046022";
            
            var paymentProvider = new FakePayPalPaymentServer();
            var transactionKey = paymentProvider.BeginTransaction(accountId);
            paymentProvider.SubmitPayment(transactionKey, authenticationToken, 15.99);
            var result = paymentProvider.CommitTransaction(transactionKey);
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("Invalid Account ID"));
        }
        [Test]
        public void ReturnErrorForForInvalidTransactionId()
        {
            const string authenticationToken = "70BD1813-5E24-4EB5-81BC-CB25F4EB8EAD";
            const string accountId = "C6BE96CA-C7D4-4D36-9852-DF1B44046022";

            var paymentProvider = new FakePayPalPaymentServer();
            var transactionKey = paymentProvider.BeginTransaction(accountId);
            paymentProvider.SubmitPayment(transactionKey, authenticationToken, 15.99);
            var result = paymentProvider.CommitTransaction(Guid.NewGuid().ToString());
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("Invalid Transaction ID"));
        }
    }
}