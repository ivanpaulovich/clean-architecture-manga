namespace WebApi.UseCases.V1.Withdraw
{
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// Withdraw Request.
    /// </summary>
    public class WithdrawRequest
    {
        /// <summary>
        /// Gets or sets the Account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the amount to withdraw.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }
    }
}