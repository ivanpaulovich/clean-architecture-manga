namespace WebApi.UseCases.V1.Deposit
{
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// The response for a successfull Deposit
    /// </summary>
    public sealed class DepositResponse
    {
        /// <summary>
        /// Amount Deposited
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

        /// <summary>
        /// Updated Balance
        /// </summary>
        [Required]
        public decimal UpdateBalance { get; }

        public DepositResponse(
            decimal amount,
            string description,
            DateTime transactionDate,
            decimal updatedBalance)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UpdateBalance = updatedBalance;
        }
    }
}