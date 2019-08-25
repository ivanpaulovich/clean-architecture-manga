namespace Manga.WebApi.UseCases.V1.CloseAccount
{
    using System;
    using System.ComponentModel.DataAnnotations;
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

        public CloseAccountResponse(Output output)
        {
            AccountId = output.AccountId;
        }
    }
}