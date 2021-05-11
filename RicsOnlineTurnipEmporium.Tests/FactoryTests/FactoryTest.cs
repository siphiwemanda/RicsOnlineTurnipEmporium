using NUnit.Framework;
using RicsOnlineTurnipEmporium.Domain;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.Factory;
using RicsOnlineTurnipEmporium.Domain.PaymentProviders;

namespace RicsOnlineTurnipEmporium.Tests.FactoryTests
{
    [TestFixture]
    public class FactoryTest
    {
        [Test]
        public void WillCreateABitCoinPaymentProvider()
        {
            var paymentProvider = ServerProviderFactory.CreatePaymentProvider(PaymentType.BitCoin,
                new BitCoinAccountDetails("93098DDA-3873-484A-B4A4-19C25438A71A",
                    "31ACD47B-60D5-4FA5-9213-D7A02C55E172", "78736511-480E-4A3C-8F07-CE4BED6E0387"));

            Assert.That(paymentProvider, Is.InstanceOf<BitCoinPaymentProvider>());
        }

        [Test]
        public void WillCreateADirectDebitPaymentProvider()
        {
            var directDebitProvider = ServerProviderFactory.CreatePaymentProvider(PaymentType.DebitCard,
                new DirectDebitAccountDetails("Manda", "77777", "444"));

            Assert.That(directDebitProvider, Is.InstanceOf<DirectDebitPaymentProvider>());
        }

        [Test]
        public void WillCreateAPayPalProvider()
        {
            var payPalProvider = ServerProviderFactory.CreatePaymentProvider(PaymentType.PayPal,
                new PayPalAccountDetails("70BD1813-5E24-4EB5-81BC-CB25F4EB8EAD"));

            Assert.That(payPalProvider, Is.InstanceOf<PayPalPaymentProvider>());
        }

        [Test]
        public void WillThrowAnErrorWhenAccountIsBitcoinButPaymentTypeIsNot()
        {
            Assert.That(
                () => ServerProviderFactory.CreatePaymentProvider(PaymentType.PayPal,
                    new BitCoinAccountDetails("93098DDA-3873-484A-B4A4-19C25438A71A",
                        "31ACD47B-60D5-4FA5-9213-D7A02C55E172", "78736511-480E-4A3C-8F07-CE4BED6E0387")),
                Throws.Exception);
        }

        [Test]
        public void WillThrowAnErrorWhenAccountIsDirectDebitButPaymentTypeIsNot()
        {
            Assert.That(
                () => ServerProviderFactory.CreatePaymentProvider(PaymentType.BitCoin,
                    new DirectDebitAccountDetails("Manda", "7777777", "444")),
                Throws.Exception);
        }

        [Test]
        public void WillThrowAnErrorWhenAccountIsPayPalButPaymentTypeIsNot()
        {
            Assert.That(
                () => ServerProviderFactory.CreatePaymentProvider(PaymentType.DebitCard,
                   new PayPalAccountDetails("70BD1813-5E24-4EB5-81BC-CB25F4EB8EAD")),
                Throws.Exception);
        }
    }
}