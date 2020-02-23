namespace WebApi.UseCases.V1.Register
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Registration Request.
    /// </summary>
    public sealed class RegisterRequest
    {
        /// <summary>
        ///     Gets or sets sSN.
        /// </summary>
        [Required]
        public string SSN { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets initial Amount.
        /// </summary>
        [Required]
        public decimal InitialAmount { get; set; } = .0M;
    }
}
