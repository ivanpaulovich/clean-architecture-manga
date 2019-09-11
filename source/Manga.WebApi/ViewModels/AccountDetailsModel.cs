namespace Manga.WebApi.ViewModels
{
    using System.Collections.Generic;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Account Details
    /// </summary>
    public sealed class AccountDetailsModel
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [Required]
        public Guid AccountId { get; }
        
        /// <summary>
        /// Current Balance
        /// </summary>
        [Required]
        public decimal CurrentBalance { get; }

        /// <summary>
        /// Transactions
        /// </summary>
        [Required]
        public List<TransactionModel> Transactions { get; }

        public AccountDetailsModel(Guid accountId, decimal currentBalance, List<TransactionModel> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }
    }
}