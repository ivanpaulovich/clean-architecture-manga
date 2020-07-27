namespace WebApi.UseCases.V1.Customers.OnBoardCustomer
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels;

    /// <summary>
    ///     The response for Registration.
    /// </summary>
    public sealed class OnBoardCustomerResponse
    {
        /// <summary>
        ///     The Response Registration Constructor.
        /// </summary>
        public OnBoardCustomerResponse(CustomerModel customerModel) => this.Customer = customerModel;

        /// <summary>
        ///     Gets customer.
        /// </summary>
        [Required]
        public CustomerModel Customer { get; }
    }
}
