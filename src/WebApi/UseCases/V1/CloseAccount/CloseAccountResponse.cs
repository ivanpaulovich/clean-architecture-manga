namespace WebApi.UseCases.V1.CloseAccount
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Application.Boundaries.CloseAccount;

    /// <summary>
    ///     Close Account Response.
    /// </summary>
    public sealed class CloseAccountResponse
    {
        public CloseAccountResponse(CloseAccountOutput output)
        {
            this.AccountId = output.AccountId.ToGuid();
        }

        /// <summary>
        ///     Gets account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; }  = Guid.Empty;
    }
}
