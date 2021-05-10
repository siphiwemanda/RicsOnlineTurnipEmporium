using RicsOnlineTurnipEmporium.Domain.AccountDetails;

namespace RicsOnlineTurnipEmporium.Domain.PaymentProviders
{
    public interface IPaymentProviders
    {
        bool MakePayment(double amount, IAccountDetails accountDetails);
    }
}