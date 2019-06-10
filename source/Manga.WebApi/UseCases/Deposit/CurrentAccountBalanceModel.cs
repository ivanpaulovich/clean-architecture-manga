namespace Manga.WebApi.UseCases.Deposit
{
    using System;

    public class CurrentAccountBalanceModel
    {
        public double Amount { get; }
        public string Description { get; }
        public DateTime TransactionDate { get; }
        public double UpdateBalance { get; }

        public CurrentAccountBalanceModel(
            double amount,
            string description,
            DateTime transactionDate,
            double updatedBalance)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UpdateBalance = updatedBalance;
        }
    }
}