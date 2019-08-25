namespace Manga.WebApi.UseCases.V1.Withdraw
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public sealed class WithdrawResponse
    {
        [Required]
        public double Amount { get; }
        
        [Required]
        public string Description { get; }
        
        [Required]
        public DateTime TransactionDate { get; }
        
        [Required]
        public double UpdateBalance { get; }

        public WithdrawResponse(double amount, string description, DateTime transactionDate, double updatedBalance)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UpdateBalance = updatedBalance;
        }
    }
}