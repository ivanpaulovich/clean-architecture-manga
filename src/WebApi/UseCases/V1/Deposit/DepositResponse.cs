namespace WebApi.UseCases.V1.Deposit
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The response for a successfull Deposit.
    /// </summary>
    public sealed class DepositResponse
    {
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

        /// <summary>
        /// Gets amount Deposited.
        /// </summary>
        [Required]
        public decimal Amount { get; }

        /// <summary>
        /// Gets description.
        /// </summary>
        [Required]
        public string Description { get; }

        /// <summary>
        /// Gets transaction Date.
        /// </summary>
        [Required]
        public DateTime TransactionDate { get; }

        /// <summary>
        /// Gets updated Balance.
        /// </summary>
        [Required]
        public decimal UpdateBalance { get; }
    }
}
