namespace WebApi.UseCases.V1.GetCustomer
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     The Customer Details.
    /// </summary>
    public sealed class GetCustomerDetailsResponse
    {
        public GetCustomerDetailsResponse(CustomerModel customerModel)
        {
            this.Customer = customerModel;
        }

        /// <summary>
        ///     Gets customer.
        /// </summary>
        [Required]
        public CustomerModel Customer { get; }
    }
}
