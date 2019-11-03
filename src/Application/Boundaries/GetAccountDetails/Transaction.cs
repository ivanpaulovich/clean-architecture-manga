namespace Application.Boundaries.GetAccountDetails
{
    using System;
    using Domain.ValueObjects;

    public sealed class Transaction
    {
        public string Description { get; }
        public Money Amount { get; }
        public DateTime TransactionDate { get; }

        public Transaction(
            string description,
            Money amount,
            DateTime transactionDate)
        {
            Description = description;
            Amount = amount;
            TransactionDate = transactionDate;
        }
    }
}