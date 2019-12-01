namespace Application.Boundaries.Transfer
{
    using System;
    using Domain.Accounts.ValueObjects;

    public sealed class Transaction
    {
        public Transaction(
            AccountId originAccountId,
            AccountId destinationAccountId,
            string description,
            PositiveMoney amount,
            DateTime transactionDate)
        {
            OriginAccountId = originAccountId;
            DestinationAccountId = destinationAccountId;
            Description = description;
            Amount = amount;
            TransactionDate = transactionDate;
        }

        public AccountId OriginAccountId { get; }

        public AccountId DestinationAccountId { get; }

        public string Description { get; }

        public PositiveMoney Amount { get; }

        public DateTime TransactionDate { get; }
    }
}
