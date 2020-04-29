namespace WebApi.UseCases.V1.Register
{
    using System.Linq;
    using Application.Boundaries.Register;
    using Domain.Accounts;
    using Domain.Customers;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    /// <summary>
    /// </summary>
    public sealed class RegisterPresenter : IRegisterOutputPort
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        /// <summary>
        /// </summary>
        /// <param name="output"></param>
        public void HandleAlreadyRegisteredCustomer(RegisterOutput output)
        {
            var customerModel = new CustomerModel((Customer)output.Customer);
            var accountsModel =
                (from Account accountEntity in output.Accounts
                    select new AccountModel(accountEntity))
                .ToList();

            var registerResponse = new RegisterResponse(customerModel, accountsModel);

            this.ViewModel = new CreatedAtRouteResult(
                "GetCustomer",
                new {customerId = registerResponse.Customer.CustomerId, version = "1.0"},
                registerResponse);
        }

        /// <summary>
        /// </summary>
        /// <param name="output"></param>
        public void Standard(RegisterOutput output)
        {
            var customerModel = new CustomerModel((Customer)output.Customer);
            var accountsModel =
                (from Account accountEntity in output.Accounts
                    select new AccountModel(accountEntity))
                .ToList();

            var registerResponse = new RegisterResponse(customerModel, accountsModel);

            this.ViewModel = new CreatedAtRouteResult(
                "GetCustomer",
                new {customerId = registerResponse.Customer.CustomerId, version = "1.0"},
                registerResponse);
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
