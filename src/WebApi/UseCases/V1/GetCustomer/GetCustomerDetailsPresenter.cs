namespace WebApi.UseCases.V1.GetCustomer
{
    using Application.Boundaries.GetCustomer;
    using Domain.Customers;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    /// <summary>
    /// Generates Get Customer presentations.
    /// </summary>
    public sealed class GetCustomerDetailsPresenter : IGetCustomerOutputPort
    {
        /// <summary>
        /// ViewModel result.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult? ViewModel { get; private set; }

        /// <summary>
        /// Customer Not found.
        /// </summary>
        /// <param name="message">Message.</param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public void Standard(GetCustomerOutput output)
        {
            var customerModel = new CustomerModel((Customer)output.Customer);
            var getCustomerDetailsResponse = new GetCustomerDetailsResponse(customerModel);
            this.ViewModel = new OkObjectResult(getCustomerDetailsResponse);
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
