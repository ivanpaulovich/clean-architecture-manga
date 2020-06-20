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
        /// <summary>
        ///     Account Details constructor.
        /// </summary>
        public AccountModel(IAccount account)
        {
            var accountEntity = (Account)account;
            this.AccountId = accountEntity.Id.ToGuid();
            this.CurrentBalance = accountEntity.GetCurrentBalance().ToDecimal();
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
