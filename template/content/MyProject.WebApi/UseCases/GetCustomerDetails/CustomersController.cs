namespace MyProject.WebApi.UseCases.GetCustomerDetails
{
    using MyProject.Application;
    using MyProject.Application.UseCases.GetCustomerDetails;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CustomersController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary<GetCustomerDetailsInput> getCustomerInput;
        private readonly Presenter getCustomerDetailsPresenter;

        public CustomersController(
            IInputBoundary<GetCustomerDetailsInput> getCustomerInput,
            Presenter getCustomerDetailsPresenter)
        {
            this.getCustomerInput = getCustomerInput;
            this.getCustomerDetailsPresenter = getCustomerDetailsPresenter;
        }

        /// <summary>
        /// Get a Customer details 
        /// </summary>
        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var request = new GetCustomerDetailsInput(customerId);
            await this.getCustomerInput.Process(request);
            return this.getCustomerDetailsPresenter.ViewModel;
        }
    }
}
