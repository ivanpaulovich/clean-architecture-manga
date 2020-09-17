namespace WebApi.UseCases.V1.Accounts.CloseAccount
{
    using Domain;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The response Close an Account.
    /// </summary>
    public sealed class CloseAccountResponse
    {
        /// <summary>
        ///     Close Account Response constructor.
        /// </summary>
        public CloseAccountResponse(Account account) => this.AccountId = account.AccountId.Id;

        /// <summary>
        ///     Gets account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; }
    }
}
