namespace WebApi.UseCases.V1.CloseAccount
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The Close Account Request.
    /// </summary>
    public sealed class CloseAccountRequest
    {
        /// <summary>
        ///     Gets or sets account ID.
        /// </summary>
        [Required]
        public Guid AccountId { get; set; } = Guid.Empty;
    }
}
