namespace Manga.WebApi.UseCases.V1.Withdraw
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Withdraw;
    using Manga.Domain.ValueObjects;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Examples;

    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public sealed class AccountsController : Controller
    {
        private readonly IUseCase _withdrawUseCase;
        private readonly WithdrawPresenter _presenter;

        public AccountsController(
            IUseCase withdrawUseCase,
            WithdrawPresenter presenter)
        {
            _withdrawUseCase = withdrawUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Withdraw on an account
        /// </summary>
        /// <response code="200">The updated balance.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to Withdraw.</param>
        /// <returns>The updated balance.</returns>
        [HttpPatch("Withdraw")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WithdrawResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(WithdrawRequest), typeof(WithdrawRequestExample))]
        public async Task<IActionResult> Withdraw([FromBody][Required] WithdrawRequest request)
        {
            await _withdrawUseCase.Execute(new Input(request.AccountId, new PositiveAmount(request.Amount)));
            return _presenter.ViewModel;
        }
    }
}