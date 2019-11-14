namespace WebApi.UseCases.V1.RegisterCustomer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The response for Registration
    /// </summary>
    public sealed class RegisterCustomerResponse
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
        /// Name
        /// </summary>
        [Required]
        public string Name { get; }

        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string Username { get; }

        public RegisterCustomerResponse(
            Guid customerId,
            string ssn,
            string name,
            string username)
        {
            CustomerId = customerId;
            SSN = ssn;
            Name = name;
            Username = username;
        }
    }
}
