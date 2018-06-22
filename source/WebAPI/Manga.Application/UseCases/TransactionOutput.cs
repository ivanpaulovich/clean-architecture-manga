namespace Manga.Application.UseCases
{
    using System;
    public sealed class TransactionOutput
    {
        public string Description { get; }
        public double Amount { get; }
        public DateTime TransactionDate { get; }

        public TransactionOutput(
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
