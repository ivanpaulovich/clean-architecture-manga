namespace WebApi.UseCases.V2.GetAccountDetails
{
    using System.ComponentModel.DataAnnotations;
    using System;

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