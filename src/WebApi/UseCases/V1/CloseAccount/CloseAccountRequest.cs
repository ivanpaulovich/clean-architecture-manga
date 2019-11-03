namespace WebApi.UseCases.V1.CloseAccount
{
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// The Close Account Request
    /// </summary>
    public sealed class CloseAccountRequest
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
    }
}