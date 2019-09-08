namespace Manga.WebApi.UseCases.V1.GetAccountDetails
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.GetAccountDetails;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Examples;

    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public sealed class AccountsController : Controller
    {
        private readonly IUseCase _getAccountDetailsUseCase;
        private readonly GetAccountDetailsPresenter _presenter;

        public AccountsController(
            IUseCase getAccountDetailsUseCase,
            GetAccountDetailsPresenter presenter)
        {
            _getAccountDetailsUseCase = getAccountDetailsUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Get an account details
        /// </summary>
        [HttpGet("{AccountId}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountDetailsResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(GetAccountDetailsRequest), typeof(GetAccountDetailsRequestExample))]
        public async Task<IActionResult> Get([FromRoute][Required] GetAccountDetailsRequest request)
        {
            var getAccountDetailsInput = new GetAccountDetailsInput(request.AccountId);
            await _getAccountDetailsUseCase.Execute(getAccountDetailsInput);
            return _presenter.ViewModel;
        }
    }
}