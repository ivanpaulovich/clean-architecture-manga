namespace WebApi.UseCases.V1.RegisterAccount
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Registration Request
    /// </summary>
    public sealed class RegisterAccountRequest
    {
        /// <summary>
        /// SSN
        /// </summary>
        [Required]
        public string SSN { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Initial Amount
        /// </summary>
        [Required]
        public decimal InitialAmount { get; set; }
    }
}
