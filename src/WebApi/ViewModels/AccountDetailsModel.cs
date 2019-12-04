namespace WebApi.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Account Details.
    /// </summary>
    public sealed class AccountDetailsModel
    {
        public AccountDetailsModel(
            AccountId accountId,
            Money currentBalance,
            List<TransactionModel> transactions)
        {
            AccountId = accountId.ToGuid();
            CurrentBalance = currentBalance.ToDecimal();
            Transactions = transactions;
        }

        /// <summary>
        /// Gets account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; }

        /// <summary>
        /// Gets current Balance.
        /// </summary>
        [Required]
        public decimal CurrentBalance { get; }

        /// <summary>
        /// Gets transactions.
        /// </summary>
        [Required]
        public List<TransactionModel> Transactions { get; }
    }
}
