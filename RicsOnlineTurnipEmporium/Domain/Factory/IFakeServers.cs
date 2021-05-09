using RicsOnlineTurnipEmporium.Domain.AccountDetails;

namespace RicsOnlineTurnipEmporium.Domain.Factory
{
    public interface IFakeServer
    {
        bool CallServer(double amount, IAccountDetails accountDetails);
    }
}