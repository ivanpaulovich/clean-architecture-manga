namespace WebApi.UseCases.V1.GetCustomerDetails
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using WebApi.ViewModels;

    /// <summary>
    /// The Customer Details
    /// </summary>
    public sealed class GetCustomerDetailsResponse
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
        public IList<AccountDetailsModel> Accounts { get; }

        public GetCustomerDetailsResponse(
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