namespace Manga.WebApi.UseCases.V1.CloseAccount
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.CloseAccount;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
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
        [HttpDelete("{AccountId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CloseAccountResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Close([FromRoute][Required] CloseAccountRequest request)
        {
            var closeAccountInput = new CloseAccountInput(request.AccountId);
            await _closeAccountUseCase.Execute(closeAccountInput);
            return _presenter.ViewModel;
        }
    }
}