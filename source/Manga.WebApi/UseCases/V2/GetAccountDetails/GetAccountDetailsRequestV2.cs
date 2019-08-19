namespace Manga.WebApi.UseCases.V2.GetAccountDetails
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The Get Account Details Request
    /// </summary>
    public sealed class GetAccountDetailsRequestV2
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
    }
}