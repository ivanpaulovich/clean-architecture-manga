namespace Manga.Application.Boundaries.GetAccountDetails
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
