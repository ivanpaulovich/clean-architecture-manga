namespace WebApi.UseCases.V1.RegisterCustomer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Registration Request
    /// </summary>
    public sealed class RegisterCustomerRequest
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
        /// Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
