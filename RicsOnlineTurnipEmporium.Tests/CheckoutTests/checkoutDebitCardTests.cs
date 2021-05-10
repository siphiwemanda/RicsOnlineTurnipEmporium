using NUnit.Framework;
using RicsOnlineTurnipEmporium.Domain;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.FakePaymentServers;

namespace RicsOnlineTurnipEmporium.Tests.CheckoutTests
{
    [TestFixture]
    public class CheckoutDebitCardTests
    {
        [Test]
        public void DebitCheckoutIsSuccessful()
        {
            var checkout = new Checkout();
            var paymentResult = checkout.MakePayment(PaymentType.DebitCard, 500,
                new DirectDebitAccountDetails("Manda", "7777777", "444"));
            Assert.That(paymentResult, Is.True);
        }

        [Test]
        public void DebitCardThrowsErrorForIncorrectPaymentType()
        {
            var checkout = new Checkout();
            Assert.That(
                () => checkout.MakePayment(PaymentType.BitCoin, 500,
                    new DirectDebitAccountDetails("Manda", "7777", "444")), Throws.Exception);
        }
    }
}