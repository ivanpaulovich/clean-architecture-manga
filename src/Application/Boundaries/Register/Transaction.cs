namespace Application.Boundaries.Register
{
    using System;
    using Domain.ValueObjects;

    public sealed class Transaction
    {
        public string Description { get; }
        public PositiveMoney Amount { get; }
        public DateTime TransactionDate { get; }

        public Transaction(
            string description,
            PositiveMoney amount,
            DateTime transactionDate)
        {
            Description = description;
            Amount = amount;
            TransactionDate = transactionDate;
        }
    }
}