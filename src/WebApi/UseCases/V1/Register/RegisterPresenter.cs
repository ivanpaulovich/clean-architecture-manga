namespace WebApi.UseCases.V1.Register
{
    using System.Linq;
    using Application.Boundaries.Register;
    using Domain.Accounts;
    using Domain.Customers;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    /// <summary>
    /// Generates the Register presentations.
    /// </summary>
    public sealed class RegisterPresenter : IRegisterOutputPort
    {
        /// <summary>
        /// ViewModel result.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult? ViewModel { get; private set; }

        /// <summary>
        /// When the customer already exists and we are returning from DB.
        /// </summary>
        /// <param name="output">Output.</param>
        public void HandleAlreadyRegisteredCustomer(RegisterOutput output)
        {
            var customerModel = new CustomerModel((Customer)output.Customer);
            var accountsModel =
                (from Account accountEntity in output.Accounts
                 select new AccountModel(accountEntity))
                .ToList();

            var registerResponse = new RegisterResponse(customerModel, accountsModel);

            this.ViewModel = new OkObjectResult(registerResponse);
        }

        /// <summary>
        /// Customer was created.
        /// </summary>
        /// <param name="output">Output.</param>
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
                new { customerId = registerResponse.Customer.CustomerId, version = "1.0" },
                registerResponse);
        }

        /// <summary>
        /// An error happened.
        /// </summary>
        /// <param name="message">Message.</param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
