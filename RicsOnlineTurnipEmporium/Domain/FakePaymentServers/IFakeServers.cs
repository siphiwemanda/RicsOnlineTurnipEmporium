using RicsOnlineTurnipEmporium.Domain.AccountDetails;

namespace RicsOnlineTurnipEmporium.Domain.FakePaymentServers
{
    public interface IFakeServer
    {
        bool CallServer(double amount, IAccountDetails accountDetails);
    }
}