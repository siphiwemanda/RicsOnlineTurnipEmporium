using NUnit.Framework;
using RicsOnlineTurnipEmporium.Domain;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;

namespace RicsOnlineTurnipEmporium.Tests.Checkout
{
    [TestFixture]
    
    public class PaypalCheckouttests
    {
        [Test]
        public void SuccsfullPaypalCheckout()
        {
            var checkout = new RicsOnlineTurnipEmporium.Checkout();
            var paymentResult = checkout.MakePayment(PaymentType.PayPal, 500, new PayPalAccountDetails("70BD1813-5E24-4EB5-81BC-CB25F4EB8EAD"));
            Assert.That(paymentResult, Is.True);
        }
    }
}