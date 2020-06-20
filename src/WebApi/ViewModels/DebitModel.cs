namespace WebApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Domain.Accounts.Debits;

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
            this.TransactionId = credit.Id.ToGuid();
            this.Amount = credit.Amount.ToMoney().ToDecimal();
            this.Description = "Debit";
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
