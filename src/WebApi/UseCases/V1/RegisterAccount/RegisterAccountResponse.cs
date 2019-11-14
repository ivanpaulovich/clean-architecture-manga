namespace WebApi.UseCases.V1.RegisterAccount
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    /// The response for Registration
    /// </summary>
    public sealed class RegisterAccountResponse
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
        /// Accounts
        /// </summary>
        [Required]
        public List<AccountDetailsModel> Accounts { get; }

        public RegisterAccountResponse(
            Guid customerId,
            string ssn,
            string name,
            List<AccountDetailsModel> accounts)
        {
            CustomerId = customerId;
            SSN = ssn;
            Name = name;
            Accounts = accounts;
        }
    }
}
