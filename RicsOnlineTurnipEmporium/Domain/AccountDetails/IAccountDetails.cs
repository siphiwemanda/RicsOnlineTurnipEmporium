namespace RicsOnlineTurnipEmporium.Domain.AccountDetails
{
    public interface IAccountDetails
    {
        bool CanHandle(PaymentType paymentType);
    }
}