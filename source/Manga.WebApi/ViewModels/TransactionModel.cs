namespace Manga.WebApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Transaction
    /// </summary>
    public sealed class TransactionModel
    {
        /// <summary>
        /// Amount
        /// </summary>
        [Required]
        public double Amount { get; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        public string Description { get; }

        /// <summary>
        /// Transaction Date
        /// </summary>
        [Required]
        public DateTime TransactionDate { get; }

        public TransactionModel(double amount, string description, DateTime transactionDate)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
        }
    }
}