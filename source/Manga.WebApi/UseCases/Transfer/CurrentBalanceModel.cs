namespace Manga.WebApi.UseCases.Transfer
{
    using System;

    public sealed class CurrentBalanceModel
    {
        public double Amount { get; }
        public string Description { get; }
        public DateTime TransactionDate { get; }
        public double UpdateBalance { get; }

        public CurrentBalanceModel(double amount, string description, DateTime transactionDate, double updatedBalance)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UpdateBalance = updatedBalance;
        }
    }
}