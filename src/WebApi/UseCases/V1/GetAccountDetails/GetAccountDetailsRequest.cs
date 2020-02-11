namespace WebApi.UseCases.V1.GetAccountDetails
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The Get Account Details Request.
    /// </summary>
    public sealed class GetAccountDetailsRequest
    {
        /// <summary>
        ///     Gets or sets account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
    }
}
