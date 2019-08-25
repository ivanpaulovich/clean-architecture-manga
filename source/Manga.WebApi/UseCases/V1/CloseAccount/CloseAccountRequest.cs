namespace Manga.WebApi.UseCases.V1.CloseAccount
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The Close Account Request
    /// </summary>
    public sealed class CloseAccountRequest
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
    }
}