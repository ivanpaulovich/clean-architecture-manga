namespace WebApi.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Account Details.
    /// </summary>
    public sealed class AccountDetailsModel
    {
        public AccountDetailsModel(
            AccountId accountId,
            Money currentBalance,
            List<TransactionModel> transactions)
        {
            this.AccountId = accountId.ToGuid();
            this.CurrentBalance = currentBalance.ToDecimal();
            this.Transactions = transactions;
        }

        /// <summary>
        ///     Gets account ID.
        /// </summary>
        [Required]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public Guid AccountId { get; }

        /// <summary>
        ///     Gets current Balance.
        /// </summary>
        [Required]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public decimal CurrentBalance { get; }

        /// <summary>
        ///     Gets transactions.
        /// </summary>
        [Required]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public List<TransactionModel> Transactions { get; }
    }
}
