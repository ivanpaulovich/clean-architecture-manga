namespace WebApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Domain.Accounts;

    /// <summary>
    ///     Account Details.
    /// </summary>
    public sealed class AccountModel
    {
        public AccountModel(IAccount account)
        {
            this.AccountId = account.Id.ToGuid();
            this.CurrentBalance = account.GetCurrentBalance().ToDecimal();
        }

        /// <summary>
        ///     Gets account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; }

        /// <summary>
        ///     Gets current Balance.
        /// </summary>
        [Required]
        public decimal CurrentBalance { get; }
    }
}
