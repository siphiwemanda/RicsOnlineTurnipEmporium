namespace RicsOnlineTurnipEmporium.Domain.FakePaymentServers
{
    public interface IFakeBitCoinPaymentServer
    {
        string Process(string request);
    }
}