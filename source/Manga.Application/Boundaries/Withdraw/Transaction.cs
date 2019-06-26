namespace Manga.Application.Boundaries.Withdraw
{
    using System;
    public sealed class Transaction
    {
        public string Description { get; }
        public double Amount { get; }
        public DateTime TransactionDate { get; }

        public Transaction(
            string description,
            double amount,
            DateTime transactionDate)
        {
            Description = description;
            Amount = amount;
            TransactionDate = transactionDate;
        }
    }
}