namespace WebApi.UseCases.V1.Withdraw
{
    using System.ComponentModel.DataAnnotations;
    using System;

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
        public decimal Amount { get; set; }
    }
}