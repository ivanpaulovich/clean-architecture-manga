namespace WebApi.UseCases.V1.CloseAccount
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Application.Boundaries.CloseAccount;

    /// <summary>
    /// Close Account Response.
    /// </summary>
    public sealed class CloseAccountResponse
    {
        public CloseAccountResponse(CloseAccountOutput output)
        {
            AccountId = output.AccountId;
        }

        /// <summary>
        /// Gets account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; }
    }
}
