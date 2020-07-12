namespace WebApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Domain.Accounts.Credits;

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
            this.Description = "Credit";
            this.TransactionDate = credit.TransactionDate;
        }

        /// <summary>
        ///     Gets Amount.
        /// </summary>
        [Required]
        public Guid TransactionId { get; }

        /// <summary>
        ///     Gets Amount.
        /// </summary>
        [Required]
        public decimal Amount { get; }

        /// <summary>
        ///     Gets Description.
        /// </summary>
        [Required]
        public string Description { get; }

        /// <summary>
        ///     Gets Transaction Date.
        /// </summary>
        [Required]
        public DateTime TransactionDate { get; }
    }
}
