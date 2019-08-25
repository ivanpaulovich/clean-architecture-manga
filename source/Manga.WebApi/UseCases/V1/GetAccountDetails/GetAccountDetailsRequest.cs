namespace Manga.WebApi.UseCases.V1.GetAccountDetails
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The Get Account Details Request
    /// </summary>
    public sealed class GetAccountDetailsRequest
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
    }
}