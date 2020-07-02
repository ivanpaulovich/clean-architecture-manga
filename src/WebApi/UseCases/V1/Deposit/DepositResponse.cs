namespace WebApi.UseCases.V1.Deposit
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The response for a successfull Deposit.
    /// </summary>
    public sealed class DepositResponse
    {
        /// <summary>
        ///     The Deposit response constructor.
        /// </summary>
        public DepositResponse(
            decimal amount,
            string description,
            DateTime transactionDate,
            decimal updatedBalance)
        {
            this.Amount = amount;
            this.Description = description;
            this.TransactionDate = transactionDate;
            this.UpdateBalance = updatedBalance;
        }

        /// <summary>
        ///     Gets amount Deposited.
        /// </summary>
        [Required]
        public decimal Amount { get; }

        /// <summary>
        ///     Gets description.
        /// </summary>
        [Required]
        public string Description { get; }

        /// <summary>
        ///     Gets transaction Date.
        /// </summary>
        [Required]
        public DateTime TransactionDate { get; }

        /// <summary>
        ///     Gets updated Balance.
        /// </summary>
        [Required]
        public decimal UpdateBalance { get; }

        /// <summary>
        ///     Get Currency.
        /// </summary>
        public string? Currency { get; set; } = "USD";
    }
}
