namespace WebApi.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Account Details.
    /// </summary>
    public sealed class AccountDetailsModel
    {
        public AccountDetailsModel(Guid accountId, decimal currentBalance, List<TransactionModel> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
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
