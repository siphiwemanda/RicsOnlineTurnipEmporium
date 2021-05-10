using System.Collections.Generic;

namespace RicsOnlineTurnipEmporium.Domain.AccountDetails
{
    public class BitCoinAccountDetails : IAccountDetails
    {
        public BitCoinAccountDetails(string receivingWalletId, string paymentWalletId, string authCode)
        {
            ReceivingWalletId = receivingWalletId;
            PaymentWalletId = paymentWalletId;
            AuthCode = authCode;
        }
        public string ReceivingWalletId { get; }
        public string PaymentWalletId { get; }
        public string AuthCode { get; }

        public bool CanHandle(PaymentType paymentType) { return paymentType == PaymentType.BitCoin; }
        public Dictionary<string, string> AccountDetails(IAccountDetails accountDetails)
        {
            throw new System.NotImplementedException();
        }
    }
}