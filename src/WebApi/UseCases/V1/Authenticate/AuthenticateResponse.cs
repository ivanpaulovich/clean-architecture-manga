namespace WebApi.UseCases.V1.Authenticate
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The response for Authenticate
    /// </summary>
    public class AuthenticateResponse
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        [Required]
        public Guid CustomerId { get; }

        /// <summary>
        /// SSN
        /// </summary>
        [Required]
        public string SSN { get; }

        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string Username { get; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; }

        /// <summary>
        /// JWT Token
        /// </summary>
        [Required]
        public string Token { get; }

        public AuthenticateResponse(
            Guid customerId,
            string ssn,
            string username,
            string name,
            string token)
        {
            CustomerId = customerId;
            SSN = ssn;
            Username = username;
            Name = name;
            Token = token;
        }
    }
}
