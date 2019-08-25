namespace Manga.WebApi.UseCases.V1.CloseAccount
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.CloseAccount;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Swashbuckle.AspNetCore.Examples;
    using System.ComponentModel.DataAnnotations;

    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public sealed class AccountsController : Controller
    {
        private readonly IUseCase _closeAccountUseCase;
        private readonly CloseAccountPresenter _presenter;

        public AccountsController(
            IUseCase closeAccountUseCase,
            CloseAccountPresenter presenter)
        {
            _closeAccountUseCase = closeAccountUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Close an Account
        /// </summary>
        /// <response code="200">The closed account id.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to Close an Account.</param>
        /// <returns>The account id.</returns>
        [HttpDelete("{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CloseAccountResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(CloseAccountRequest), typeof(CloseAccountRequestExample))]
        public async Task<IActionResult> Close([FromRoute][Required] CloseAccountRequest request)
        {
            await _closeAccountUseCase.Execute(new Input(request.AccountId));
            return _presenter.ViewModel;
        }
    }
}