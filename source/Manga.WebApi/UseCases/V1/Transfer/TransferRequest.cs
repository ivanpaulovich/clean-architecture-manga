namespace Manga.WebApi.UseCases.V1.Transfer
{
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// Transfer Request
    /// </summary>
    public sealed class TransferRequest
    {
        /// <summary>
        /// Origin Account ID
        /// </summary>
        [Required]
        public Guid OriginAccountId { get; set; }

        /// <summary>
        /// Destination Account ID
        /// </summary>
        [Required]
        public Guid DestinationAccountId { get; set; }

        /// <summary>
        /// Amount Transferred
        /// </summary>
        [Required]
        public Double Amount { get; set; }
    }
}