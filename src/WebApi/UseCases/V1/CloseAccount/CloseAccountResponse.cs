namespace WebApi.UseCases.V1.CloseAccount
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Application.Boundaries.CloseAccount;

    /// <summary>
    ///     The response Close an Account.
    /// </summary>
    public sealed class CloseAccountResponse
    {
        /// <summary>
        ///     Close Account Response constructor.
        /// </summary>
        public CloseAccountResponse(CloseAccountOutput output) => this.AccountId = output.Account.Id.ToGuid();

        /// <summary>
        ///     Gets account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; } = Guid.Empty;
    }
}
