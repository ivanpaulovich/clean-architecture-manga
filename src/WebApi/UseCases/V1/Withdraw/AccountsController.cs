namespace WebApi.UseCases.V1.Withdraw
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.Withdraw;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using FluentMediator;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly WithdrawPresenter _presenter;

        public AccountsController(
            IMediator mediator,
            WithdrawPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Withdraw on an account.
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
        public async Task<IActionResult> Withdraw([FromForm][Required] WithdrawRequest request)
        {
            var input = new WithdrawInput(
                new AccountId(request.AccountId),
                new PositiveMoney(request.Amount));
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
