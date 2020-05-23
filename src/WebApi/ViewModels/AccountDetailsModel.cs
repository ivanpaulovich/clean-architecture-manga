namespace WebApi.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;

    /// <summary>
    ///     Account Details.
    /// </summary>
    public sealed class AccountDetailsModel
    {
        public AccountDetailsModel(IAccount account)
        {
            var accountEntity = (Account)account;
            this.AccountId = accountEntity.Id.ToGuid();
            this.CurrentBalance = accountEntity.GetCurrentBalance().ToDecimal();
            this.Credits = accountEntity
                .Credits
                .Select(e => new CreditModel((Credit)e))
                .ToList();

            this.Debits = accountEntity
                .Debits
                .Select(e => new DebitModel((Debit)e))
                .ToList();
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

        [Required] public List<CreditModel> Credits { get; } = new List<CreditModel>();

        [Required] public List<DebitModel> Debits { get; } = new List<DebitModel>();
    }
}
