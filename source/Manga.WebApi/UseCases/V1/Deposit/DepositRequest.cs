namespace Manga.WebApi.UseCases.V1.Deposit
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The request to Deposit
    /// </summary>
    public sealed class DepositRequest
    {
        /// <summary>
        /// The Account ID
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
        
        /// <summary>
        /// The amount to Deposit
        /// </summary>
        [Required]
        public Double Amount { get; set; }
    }
}