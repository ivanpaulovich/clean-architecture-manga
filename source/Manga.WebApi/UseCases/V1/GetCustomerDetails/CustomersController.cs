namespace Manga.WebApi.UseCases.V1.GetCustomerDetails
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.GetCustomerDetails;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public sealed class CustomersController : ControllerBase
    {
        private readonly IUseCase _getCustomerDetailsUseCase;
        private readonly GetCustomerDetailsPresenter _presenter;

        public CustomersController(
            IUseCase getCustomerDetailsUseCase,
            GetCustomerDetailsPresenter presenter)
        {
            _getCustomerDetailsUseCase = getCustomerDetailsUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Get the Customer details 
        /// </summary>
        [HttpGet("{CustomerId}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCustomerDetailsResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomer([FromRoute][Required] GetCustomerDetailsRequest request)
        {
            var getCustomerDetailsInput = new GetCustomerDetailsInput(request.CustomerId);
            await _getCustomerDetailsUseCase.Execute(getCustomerDetailsInput);
            return _presenter.ViewModel;
        }
    }
}