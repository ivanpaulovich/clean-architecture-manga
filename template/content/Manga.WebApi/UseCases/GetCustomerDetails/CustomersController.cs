namespace Manga.WebApi.UseCases.GetCustomerDetails
{
    using Manga.Application.UseCases;
    using Manga.Application.UseCases.GetCustomerDetails;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IGetCustomerDetailsUseCase _getCustomerDetailsUseCase;
        private readonly Presenter _presenter;

        public CustomersController(
            IGetCustomerDetailsUseCase getCustomerDetailsUseCase,
            Presenter presenter)
        {
            _getCustomerDetailsUseCase = getCustomerDetailsUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Get a Customer details 
        /// </summary>
        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            CustomerOutput output = await _getCustomerDetailsUseCase.Execute(customerId);
            _presenter.Populate(output);
            return _presenter.ViewModel;
        }
    }
}
