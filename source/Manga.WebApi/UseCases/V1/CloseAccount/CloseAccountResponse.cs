namespace Manga.WebApi.UseCases.V1.CloseAccount
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using Manga.Application.Boundaries.CloseAccount;

    /// <summary>
    /// Close Account Response
    /// </summary>
    public sealed class CloseAccountResponse
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [Required]
        public Guid AccountId { get; }

        public CloseAccountResponse(CloseAccountOutput output)
        {
            AccountId = output.AccountId;
        }
    }
}
