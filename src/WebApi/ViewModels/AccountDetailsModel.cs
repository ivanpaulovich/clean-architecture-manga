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
        /// <summary>
        ///     Account Details constructor.
        /// </summary>
        public AccountDetailsModel(Account account)
        {
            this.AccountId = account.AccountId.Id;
            this.CurrentBalance = account.GetCurrentBalance().Amount;
            this.Credits = account
                .Credits
                .Select(e => new CreditModel((Credit)e))
                .ToList();

            this.Debits = account
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

        /// <summary>
        ///     Gets Credits.
        /// </summary>
        [Required]
        public List<CreditModel> Credits { get; }

        /// <summary>
        ///     Gets Debits.
        /// </summary>
        [Required]
        public List<DebitModel> Debits { get; }
    }
}
