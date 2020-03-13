namespace WebApi.UseCases.V1.GetCustomer
{
    using Application.Boundaries.GetCustomer;
    using Domain.Customers;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public sealed class GetCustomerDetailsPresenter : IGetCustomerOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            this.ViewModel = new NotFoundObjectResult(message);
        }

        public void Standard(GetCustomerOutput getCustomerDetailsOutput)
        {
            var customerModel = new CustomerModel((Customer)getCustomerDetailsOutput.Customer);
            var getCustomerDetailsResponse = new GetCustomerDetailsResponse(customerModel);
            this.ViewModel = new OkObjectResult(getCustomerDetailsResponse);
        }

        public void WriteError(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }
    }
}
