namespace WebApi.UseCases.V1.Customers.UpdateCustomer
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     The response for Registration.
    /// </summary>
    public sealed class UpdateCustomerResponse
    {
        /// <summary>
        ///     The Response Registration Constructor.
        /// </summary>
        public UpdateCustomerResponse(CustomerModel customerModel) => this.Customer = customerModel;

        /// <summary>
        ///     Gets customer.
        /// </summary>
        [Required]
        public CustomerModel Customer { get; }
    }
}
