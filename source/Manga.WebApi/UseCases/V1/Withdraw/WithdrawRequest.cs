namespace Manga.WebApi.UseCases.V1.Withdraw
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Withdraw Request
    /// </summary>
    public class WithdrawRequest
    {
        /// <summary>
        /// The Account ID
        /// </summary>
        /// <value></value>
        [Required]
        public Guid AccountId { get; set; }
        
        /// <summary>
        /// The amount to withdraw
        /// </summary>
        [Required]
        public Double Amount { get; set; }
    }
}