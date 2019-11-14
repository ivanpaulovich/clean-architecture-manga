namespace WebApi.UseCases.V1.Authenticate
{
    using System.ComponentModel.DataAnnotations;

    public sealed class AuthenticateRequest
    {
        /// <summary>
        /// Customer Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Customer Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
