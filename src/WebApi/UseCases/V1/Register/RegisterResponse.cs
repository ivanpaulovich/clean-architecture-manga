namespace WebApi.UseCases.V1.Register
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Domain.Customers.ValueObjects;
    using ViewModels;

    /// <summary>
    ///     The response for Registration.
    /// </summary>
    public sealed class RegisterResponse
    {
        public RegisterResponse(
            CustomerId customerId,
            SSN ssn,
            Name name,
            List<AccountDetailsModel> accounts)
        {
            this.CustomerId = customerId.ToGuid();
            this.SSN = ssn.ToString();
            this.Name = name.ToString();
            this.Accounts = accounts;
        }

        /// <summary>
        ///     Gets customer ID.
        /// </summary>
        [Required]
        public Guid CustomerId { get; }

        /// <summary>
        ///     Gets sSN.
        /// </summary>
        [Required]
        public string SSN { get; }

        /// <summary>
        ///     Gets name.
        /// </summary>
        [Required]
        public string Name { get; }

        /// <summary>
        ///     Gets accounts.
        /// </summary>
        [Required]
        public List<AccountDetailsModel> Accounts { get; }
    }
}
