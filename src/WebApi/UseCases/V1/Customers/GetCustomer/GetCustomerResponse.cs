namespace WebApi.UseCases.V1.Customers.GetCustomer
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     The Customer Details.
    /// </summary>
    public sealed class GetCustomerResponse
    {
        /// <summary>
        ///     The Get Customer Details Response constructor.
        /// </summary>
        public GetCustomerResponse(CustomerModel customerModel) => this.Customer = customerModel;

        /// <summary>
        ///     Gets customer.
        /// </summary>
        [Required]
        public CustomerModel Customer { get; }
    }
}
