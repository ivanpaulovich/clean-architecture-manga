namespace Manga.WebApi.UseCases.V1.GetAccountDetails
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using Manga.WebApi.ViewModels;

    /// <summary>
    /// Get Account Details
    /// </summary>
    public sealed class GetAccountDetailsResponse
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
        public IList<TransactionModel> Transactions { get; }

        public GetAccountDetailsResponse(Guid accountId, decimal currentBalance, List<TransactionModel> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }
    }
}
