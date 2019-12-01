namespace Application.Boundaries.GetCustomerDetails
{
    using System;
    using Domain.Accounts.ValueObjects;

    public sealed class Transaction
    {
        public Transaction(
            string description,
            PositiveMoney amount,
            DateTime transactionDate)
        {
            Description = description;
            Amount = amount;
            TransactionDate = transactionDate;
        }

        public string Description { get; }

        public PositiveMoney Amount { get; }

        public DateTime TransactionDate { get; }
    }
}
