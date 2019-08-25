namespace Manga.WebApi.UseCases.V2.GetAccountDetails
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using Manga.WebApi.Models;

    /// <summary>
    /// Get Account Details Response
    /// </summary>
    public sealed class GetAccountDetailsResponseV2
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
        public double CurrentBalance { get; }

        /// <summary>
        /// Transactions
        /// </summary>
        [Required]
        public IList<TransactionModel> Transactions { get; }

        public GetAccountDetailsResponseV2(Guid accountId, double currentBalance, List<TransactionModel> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }
    }
}