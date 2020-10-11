namespace WebApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Domain.Debits;

    /// <summary>
    ///     Debit.
    /// </summary>
    public sealed class DebitModel
    {
        /// <summary>
        ///     Debit constructor.
        /// </summary>
        public DebitModel(Debit credit)
        {
            this.TransactionId = credit.DebitId.Id;
            this.Amount = credit.Amount.Amount;
            this.Currency = credit.Amount.Currency.Code;
            this.Description = "Debit";
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
