using NUnit.Framework;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium.Tests.PaymentProviders
{
    [TestFixture]
    public class DebitCardPaymentServerWill
    {
        [Test]
        public void ReturnTransactionIdForSuccessfulPayment()
        {
            const string userId = "ROTE-0001UK";
            const string cardHolder = "Ms. Hayley Miles";
            const string cardNumber = "9111111111111111";
            const string cvv = "303";
            var paymentProvider = new FakeDirectDebitPaymentServer(userId);
            var result = paymentProvider.MakePayment(cardHolder, cardNumber, cvv, 10.99);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ThrowExceptionForInvalidUserId()
        {
            const string userId = "NOT-VALID";
            const string cardHolder = "Ms. Hayley Miles";
            const string cardNumber = "9111111111111111";
            const string cvv = "303";
            var paymentProvider = new FakeDirectDebitPaymentServer(userId);

            Assert.That(() => paymentProvider.MakePayment(cardHolder, cardNumber, cvv, 10.99), Throws.Exception);
        }
    }
}