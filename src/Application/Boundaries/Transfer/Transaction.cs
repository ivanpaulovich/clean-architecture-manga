namespace Application.Boundaries.Transfer
{
    using System;
    using Domain.ValueObjects;

    public sealed class Transaction
    {
        public Transaction(
            Guid originAccountId,
            Guid destinationAccountId,
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

        public Guid OriginAccountId { get; }

        public Guid DestinationAccountId { get; }

        public string Description { get; }

        public PositiveMoney Amount { get; }

        public DateTime TransactionDate { get; }
    }
}
