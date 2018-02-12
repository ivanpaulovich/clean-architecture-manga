namespace Manga.UI.Model
{
    using System;

    public class WithdrawModel
    {
        public double Amount { get; }
        public string Description { get; }
        public DateTime TransactionDate { get; }
        public double UpdateBalance { get; }

        public WithdrawModel(double amount, string description, DateTime transactionDate, double updatedBalance)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UpdateBalance = updatedBalance;
        }
    }
}