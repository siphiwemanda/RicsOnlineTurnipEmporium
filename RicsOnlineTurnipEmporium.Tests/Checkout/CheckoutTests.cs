using NUnit.Framework;
using RicsOnlineTurnipEmporium.Domain;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;


namespace RicsOnlineTurnipEmporium.Tests.Checkout
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void ReturnSucessfulResultForPaymentForBitcoin()
        {
            var test = new RicsOnlineTurnipEmporium.Checkout();
            var payment = test.MakePayment(PaymentType.BitCoin, 0,  new BitCoinAccountDetails("93098DDA-3873-484A-B4A4-19C25438A71A", "31ACD47B-60D5-4FA5-9213-D7A02C55E172", "78736511-480E-4A3C-8F07-CE4BED6E0387"));
            
            Assert.That(payment, Is.True);
        }
    }
}