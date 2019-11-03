namespace WebApi.UseCases.V1.GetAccountDetails
{
    using System.ComponentModel.DataAnnotations;
    using System;

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