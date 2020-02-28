namespace WebApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Transaction.
    /// </summary>
    public sealed class TransactionModel
    {
        public TransactionModel(PositiveMoney amount, string description, DateTime transactionDate)
        {
            this.Amount = amount.ToMoney().ToDecimal();
            this.Description = description;
            this.TransactionDate = transactionDate;
        }

        /// <summary>
        ///     Gets Amount.
        /// </summary>
        [Required]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public decimal Amount { get; }

        /// <summary>
        ///     Gets Description.
        /// </summary>
        [Required]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public string Description { get; }

        /// <summary>
        ///     Gets Transaction Date.
        /// </summary>
        [Required]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public DateTime TransactionDate { get; }
    }
}
