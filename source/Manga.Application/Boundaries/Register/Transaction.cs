namespace Manga.Application.Boundaries.Register
{
    using System;
    public sealed class Transaction
    {
        public string Description { get; }
        public decimal Amount { get; }
        public DateTime TransactionDate { get; }

        public Transaction(
            string description,
            decimal amount,
            DateTime transactionDate)
        {
            Description = description;
            Amount = amount;
            TransactionDate = transactionDate;
        }
    }
}