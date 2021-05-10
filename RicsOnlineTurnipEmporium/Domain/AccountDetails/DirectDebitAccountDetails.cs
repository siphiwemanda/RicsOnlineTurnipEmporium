﻿namespace RicsOnlineTurnipEmporium.Domain.AccountDetails
{
    public class DirectDebitAccountDetails : IAccountDetails
    {
        public DirectDebitAccountDetails(string cardHolder, string cardNumber, string cvv)
        {
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            Cvv = cvv;
        }
        public string CardHolder { get; }
        public string CardNumber { get; }
        public string Cvv { get; }
        public bool CanHandle(PaymentType paymentType) { return paymentType == PaymentType.DebitCard; }
    }
}