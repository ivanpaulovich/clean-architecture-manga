namespace MyProject.WebApi.UseCases.Withdraw
{
    using System;

    public class Model
    {
        public double Amount { get; }
        public string Description { get; }
        public DateTime TransactionDate { get; }
        public double UpdateBalance { get; }

        public Model(double amount, string description, DateTime transactionDate, double updatedBalance)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UpdateBalance = updatedBalance;
        }
    }
}