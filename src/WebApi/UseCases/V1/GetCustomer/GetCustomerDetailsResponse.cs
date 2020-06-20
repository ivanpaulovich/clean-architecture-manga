namespace WebApi.UseCases.V1.GetCustomer
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     The Customer Details.
    /// </summary>
    public sealed class GetCustomerDetailsResponse
    {
        /// <summary>
        ///     The Get Customer Details Response constructor.
        /// </summary>
        public GetCustomerDetailsResponse(CustomerModel customerModel) => this.Customer = customerModel;

        /// <summary>
        ///     Gets customer.
        /// </summary>
        [Required]
        public CustomerModel Customer { get; }
    }
}
