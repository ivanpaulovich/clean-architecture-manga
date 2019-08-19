namespace Manga.WebApi.UseCases.V2.GetAccountDetails
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.GetAccountDetails;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Swashbuckle.AspNetCore.Examples;
    using System.ComponentModel.DataAnnotations;

    [ApiVersion("2.0")]
    [Route("api/v2/[controller]")]
    [ApiController]
    public sealed class AccountsV2Controller : Controller
    {
        private readonly IUseCase _getAccountDetailsUseCase;
        private readonly GetAccountDetailsPresenterV2 _presenter;

        public AccountsV2Controller(
            IUseCase getAccountDetailsUseCase,
            GetAccountDetailsPresenterV2 presenter)
        {
            _getAccountDetailsUseCase = getAccountDetailsUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Get an account details
        /// </summary>
        [HttpGet("{accountId}", Name = "GetAccountV2")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountDetailsResponseV2))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(GetAccountDetailsRequestV2), typeof(GetAccountDetailsRequestExampleV2))]
        public async Task<IActionResult> Get([FromRoute][Required] GetAccountDetailsRequestV2 request)
        {
            await _getAccountDetailsUseCase.Execute(new Input(request.AccountId));
            return _presenter.ViewModel;
        }
    }
}