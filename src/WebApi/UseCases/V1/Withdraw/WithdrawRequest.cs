namespace WebApi.UseCases.V1.Withdraw
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Withdraw Request.
    /// </summary>
    public sealed class WithdrawRequest
    {
        /// <summary>
        ///     Gets or sets the Account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the amount to withdraw.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }
    }
}
