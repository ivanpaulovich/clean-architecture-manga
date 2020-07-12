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
            this.CustomerId = customer.CustomerId.Id;
            this.SSN = customer.SSN.Text;
            this.FirstName = customer.FirstName.Text;
            this.LastName = customer.LastName.Text;
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
        public string FirstName { get; }

        /// <summary>
        ///     Gets name.
        /// </summary>
        [Required]
        public string LastName { get; }
    }
}
