namespace Manga.UI.Controllers
{
    using Manga.Application;
    using Manga.Application.UseCases.GetCustomerDetails;
    using Manga.Application.UseCases.Register;
    using Manga.UI.Presenters;
    using Manga.UI.Requests;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IInputBoundary<RegisterCommand> registerInput;
        private readonly IInputBoundary<GetCustomerDetaisCommand> getCustomerInput;

        private readonly RegisterPresenter registerPresenter;
        private readonly CustomerDetailsPresenter getCustomerDetailsPresenter;

        public CustomersController(
            IInputBoundary<RegisterCommand> registerInput,
            IInputBoundary<GetCustomerDetaisCommand> getCustomerInput,
            RegisterPresenter registerPresenter,
            CustomerDetailsPresenter getCustomerDetailsPresenter)
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
            var request = new RegisterCommand(message.PIN, message.Name, message.InitialAmount);
            await registerInput.Handle(request);
            return registerPresenter.ViewModel;
        }

        /// <summary>
        /// Get a Customer details 
        /// </summary>
        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var request = new GetCustomerDetaisCommand(customerId);
            await this.getCustomerInput.Handle(request);
            return this.getCustomerDetailsPresenter.ViewModel;
        }
    }
}
