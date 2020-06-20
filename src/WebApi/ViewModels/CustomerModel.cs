namespace WebApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Domain.Customers;

    /// <summary>
    ///     Customer.
    /// </summary>
    public sealed class CustomerModel
    {
        /// <summary>
        ///     Customer constructor.
        /// </summary>
        public CustomerModel(Customer customer)
        {
            this.CustomerId = customer.Id.ToGuid();
            this.SSN = customer.SSN.ToString();
            this.Name = customer.Name.ToString();
        }

        /// <summary>
        ///     Gets customer ID.
        /// </summary>
        [Required]
        public Guid CustomerId { get; }

        /// <summary>
        ///     Gets SSN.
        /// </summary>
        [Required]
        public string SSN { get; }

        /// <summary>
        ///     Gets name.
        /// </summary>
        [Required]
        public string Name { get; }
    }
}
