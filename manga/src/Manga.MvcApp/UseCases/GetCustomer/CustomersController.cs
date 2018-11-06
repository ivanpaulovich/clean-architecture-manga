namespace Manga.MvcApp.UseCases.GetCustomer
{
    using Manga.Application.UseCases;
    using Manga.Application.UseCases.GetCustomerDetails;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public sealed class CustomersController : Controller
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

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            CustomerOutput output = await _getCustomerDetailsUseCase.Execute(customerId);
            _presenter.Populate(output, this);
            return _presenter.ViewModel;
        }
    }
}
