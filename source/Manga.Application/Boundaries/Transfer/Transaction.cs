namespace Manga.Application.Boundaries.Transfer
{
    using System;
    public sealed class Transaction
    {
        public Guid OriginAccountId { get; }
        public Guid DestinationAccountId { get; }
        public string Description { get; }
        public decimal Amount { get; }
        public DateTime TransactionDate { get; }

        public Transaction(
            Guid originAccountId,
            Guid destinationAccountId,
            string description,
            decimal amount,
            DateTime transactionDate)
        {
            OriginAccountId = originAccountId;
            DestinationAccountId = destinationAccountId;
            Description = description;
            Amount = amount;
            TransactionDate = transactionDate;
        }
    }
}