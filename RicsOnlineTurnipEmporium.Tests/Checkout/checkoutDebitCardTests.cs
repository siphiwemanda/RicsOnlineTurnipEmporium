using NUnit.Framework;
using RicsOnlineTurnipEmporium.Domain;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;

namespace RicsOnlineTurnipEmporium.Tests.Checkout
{
    
    [TestFixture]
    public class CheckoutDebitCardTests
    {
        [Test]
        public void DebitCardSussesfullPayment()
        {
            var checkout = new RicsOnlineTurnipEmporium.Checkout();
            var paymentResult = checkout.MakePayment(PaymentType.DebitCard, 500,
                new DirectDebitAccountDetails("Manda", "7777777", "444"));
            Assert.That(paymentResult, Is.True);

        }

    }
}