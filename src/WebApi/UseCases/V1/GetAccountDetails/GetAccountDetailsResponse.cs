namespace WebApi.UseCases.V1.GetAccountDetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WebApi.ViewModels;

    /// <summary>
    /// Get Account Details.
    /// </summary>
    public sealed class GetAccountDetailsResponse
    {
        public GetAccountDetailsResponse(Guid accountId, decimal currentBalance, List<TransactionModel> transactions)
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
        public IList<TransactionModel> Transactions { get; }
    }
}
