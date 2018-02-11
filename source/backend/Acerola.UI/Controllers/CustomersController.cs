namespace Acerola.UI.Controllers
{
    using Acerola.Application;
    using Acerola.UI.Presenters;
    using Acerola.UI.Requests;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CustomersController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary<Application.UseCases.Register.Request> registerInput;
        private readonly IInputBoundary<Application.UseCases.GetCustomerDetails.Request> getCustomerInput;

        private readonly RegisterPresenter registerPresenter;
        private readonly GetCustomerDetailsPresenter getCustomerDetailsPresenter;

        public CustomersController(
            IInputBoundary<Application.UseCases.Register.Request> registerInput,
            IInputBoundary<Application.UseCases.GetCustomerDetails.Request> getCustomerInput,
            RegisterPresenter registerPresenter,
            GetCustomerDetailsPresenter getCustomerDetailsPresenter)
        {
            this.registerInput = registerInput;
            this.getCustomerInput = getCustomerInput;
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
    }
}
