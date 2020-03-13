namespace WebApi.UseCases.V1.GetAccount
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The Get Account Details Request.
    /// </summary>
    public sealed class GetAccountRequest
    {
        /// <summary>
        ///     Gets or sets account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
    }
}
