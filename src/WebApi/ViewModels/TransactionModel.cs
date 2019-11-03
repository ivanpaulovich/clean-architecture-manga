namespace WebApi.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// Transaction
    /// </summary>
    public sealed class TransactionModel
    {
        /// <summary>
        /// Amount
        /// </summary>
        [Required]
        public decimal Amount { get; }

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

        public TransactionModel(decimal amount, string description, DateTime transactionDate)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
        }
    }
}