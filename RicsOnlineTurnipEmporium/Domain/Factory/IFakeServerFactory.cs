namespace RicsOnlineTurnipEmporium.Domain.Factory
{
    public interface IFakeServerFactory
    {
        bool CanHandle(PaymentType paymentType);
    }
}