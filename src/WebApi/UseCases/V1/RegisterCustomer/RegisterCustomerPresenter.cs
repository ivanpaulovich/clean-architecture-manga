namespace WebApi.UseCases.V1.RegisterCustomer
{
    using Application.Boundaries.RegisterCustomer;
    using Microsoft.AspNetCore.Mvc;

    public sealed class RegisterCustomerPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Standard(RegisterCustomerOutput output)
        {
            var registerResponse = new RegisterCustomerResponse(
                output.Customer.CustomerId,
                output.Customer.SSN.ToString(),
                output.Customer.Name.ToString(),
                output.Customer.Username.ToString()
            );

            ViewModel = new CreatedAtRouteResult("GetCustomer",
                new
                {
                    customerId = registerResponse.CustomerId
                },
                registerResponse);
        }
    }
}
