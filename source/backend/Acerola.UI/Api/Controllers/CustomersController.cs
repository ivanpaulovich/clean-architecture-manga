namespace Acerola.UI.UseCases.Customers.Register
{
    using Acerola.Application;
    using Acerola.UI.Api.Presenters;
    using Acerola.UI.Requests;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CustomersController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary<Application.UseCases.ListAllCustomers.Request> listAllCustomersInput;
        private readonly IInputBoundary<Application.UseCases.Register.Request> registerInput;
        private readonly IInputBoundary<Application.UseCases.GetCustomerDetails.Request> getCustomerInput;

        private readonly ListAllCustomersPresenter listAllCustomersPresenter;
        private readonly RegisterPresenter registerPresenter;
        private readonly GetAccountDetailsPresenter getCustomerDetailsPresenter;

        public CustomersController(
            IInputBoundary<Application.UseCases.ListAllCustomers.Request> listAllCustomersInput,
            IInputBoundary<Application.UseCases.Register.Request> registerInput,
            IInputBoundary<Application.UseCases.GetCustomerDetails.Request> getCustomerInput,
            ListAllCustomersPresenter listAllCustomersPresenter,
            RegisterPresenter registerPresenter,
            GetAccountDetailsPresenter getCustomerDetailsPresenter)
        {
            this.listAllCustomersInput = listAllCustomersInput;
            this.registerInput = registerInput;
            this.getCustomerInput = getCustomerInput;
            this.listAllCustomersPresenter = listAllCustomersPresenter;
            this.registerPresenter = registerPresenter;
            this.getCustomerDetailsPresenter = getCustomerDetailsPresenter;
        }

        /// <summary>
        /// Register a new Customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterRequest message)
        {
            var request = new Application.UseCases.Register.Request(message.PIN, message.Name, message.InitialAmount);
            await registerInput.Handle(request);
            return registerPresenter.ViewModel;
        }

        /// <summary>
        /// Get a Customer details 
        /// </summary>
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var request = new Application.UseCases.GetCustomerDetails.Request(id);
            await this.getCustomerInput.Handle(request);
            return this.getCustomerDetailsPresenter.ViewModel;
        }

        /// <summary>
        /// List all customers
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = new Application.UseCases.ListAllCustomers.Request();
            await this.listAllCustomersInput.Handle(request);
            return this.listAllCustomersPresenter.ViewModel;
        }
    }
}
