namespace WebApi.UseCases.V1.Register
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Registration Request
    /// </summary>
    public sealed class RegisterRequest
    {
        /// <summary>
        /// SSN
        /// </summary>
        [Required]
        public string SSN { get; set; }

        /// <summary>
        /// Initial Amount
        /// </summary>
        [Required]
        public decimal InitialAmount { get; set; }
    }
}