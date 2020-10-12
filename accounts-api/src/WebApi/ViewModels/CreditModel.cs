namespace WebApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Domain.Credits;

    /// <summary>
    ///     Credit.
    /// </summary>
    public sealed class CreditModel
    {
        /// <summary>
        ///     Credit constructor.
        /// </summary>
        public CreditModel(Credit credit)
        {
            this.TransactionId = credit.CreditId.Id;
            this.Amount = credit.Amount.Amount;
            this.Currency = credit.Amount.Currency.Code;
            this.Description = "Credit";
            this.TransactionDate = credit.TransactionDate;
        }

        /// <summary>
        ///     Gets the TransactionId.
        /// </summary>
        [Required]
        public Guid TransactionId { get; }

        /// <summary>
        ///     Gets the Amount.
        /// </summary>
        [Required]
        public decimal Amount { get; }

        /// <summary>
        ///     Gets the Currency.
        /// </summary>
        [Required]
        public string Currency { get; }

        /// <summary>
        ///     Gets the Description.
        /// </summary>
        [Required]
        public string Description { get; }

        /// <summary>
        ///     Gets the Transaction Date.
        /// </summary>
        [Required]
        public DateTime TransactionDate { get; }
    }
}
