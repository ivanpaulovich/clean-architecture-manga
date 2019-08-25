namespace Manga.WebApi.UseCases.V1.Transfer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public sealed class TransferResponse
    {
        [Required]
        public double Amount { get; }
        
        [Required]
        public string Description { get; }
        
        [Required]
        public DateTime TransactionDate { get; }
        
        [Required]
        public double UpdateBalance { get; }

        public TransferResponse(double amount, string description, DateTime transactionDate, double updatedBalance)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UpdateBalance = updatedBalance;
        }
    }
}