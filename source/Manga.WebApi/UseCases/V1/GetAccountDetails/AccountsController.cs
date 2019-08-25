namespace Manga.WebApi.UseCases.V1.GetAccountDetails
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.GetAccountDetails;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Swashbuckle.AspNetCore.Examples;
    using System.ComponentModel.DataAnnotations;

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
        [HttpGet("{accountId}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountDetailsResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(GetAccountDetailsRequest), typeof(GetAccountDetailsRequestExample))]
        public async Task<IActionResult> Get([FromRoute][Required] GetAccountDetailsRequest request)
        {
            await _getAccountDetailsUseCase.Execute(new Input(request.AccountId));
            return _presenter.ViewModel;
        }
    }
}