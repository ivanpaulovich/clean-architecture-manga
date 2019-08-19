namespace Manga.WebApi.UseCases.V1.Deposit
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The response for a successfull Deposit
    /// </summary>
    public sealed class DepositResponse
    {
        /// <summary>
        /// Amount Deposited
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

        /// <summary>
        /// Updated Balance
        /// </summary>
        [Required]
        public double UpdateBalance { get; }

        public DepositResponse(
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