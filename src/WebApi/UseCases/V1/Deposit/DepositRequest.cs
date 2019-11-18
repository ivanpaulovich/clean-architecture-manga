namespace WebApi.UseCases.V1.Deposit
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The request to Deposit.
    /// </summary>
    public sealed class DepositRequest
    {
        /// <summary>
        /// Gets or sets the Account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the amount to Deposit.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }
    }
}