namespace Manga.WebApi.UseCases.GetCustomerDetails
{
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.GetCustomerDetails;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IUseCase _getCustomerDetailsUseCase;
        private readonly Presenter _presenter;

        public CustomersController(
            IUseCase getCustomerDetailsUseCase,
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
            await _getCustomerDetailsUseCase.Execute(new Input(customerId));
            return _presenter.ViewModel;
        }
    }
}