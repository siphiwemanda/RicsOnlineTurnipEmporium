using System;
using System.Collections.Generic;
using RicsOnlineTurnipEmporium.Domain.AccountDetails;
using RicsOnlineTurnipEmporium.Domain.Factory;

namespace RicsOnlineTurnipEmporium.Domain.FakePaymentServers
{
    public class FakePayPalPaymentServer : IFakeServer
    {
        private readonly Dictionary<string, string> _transactions = new Dictionary<string, string>();
        private const string AccountId = "C6BE96CA-C7D4-4D36-9852-DF1B44046022";

        public string BeginTransaction(string accountId)
        {
            var transactionId = Guid.NewGuid().ToString();
            _transactions.Add(transactionId, accountId);
            return transactionId;
        }

        public void SubmitPayment(string transactionKey, string authenticationToken, double amount) { }

        public PayPalTransactionResult CommitTransaction(string transactionKey)
        {
            if (!_transactions.ContainsKey(transactionKey))
                return new PayPalTransactionResult(false, "Invalid Transaction ID");
            if (_transactions[transactionKey] != AccountId)
                return new PayPalTransactionResult(false, "Invalid Account ID");
            return new PayPalTransactionResult(true, string.Empty);
        }


        public bool CallServer(double amount, IAccountDetails accountDetails)
        {
            var clientDetails = accountDetails.AccountDetails(accountDetails);
            var transactionKey = BeginTransaction("C6BE96CA-C7D4-4D36-9852-DF1B44046022");
            SubmitPayment(transactionKey, clientDetails["AuthenticationToken"], amount);
            var res = CommitTransaction(transactionKey);
            return res.Success;
        }
    }
}