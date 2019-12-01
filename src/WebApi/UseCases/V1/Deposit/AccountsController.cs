namespace WebApi.UseCases.V1.Deposit
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;
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
        private readonly DepositPresenter _presenter;

        public AccountsController(
            IMediator mediator,
            DepositPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Deposit on an account.
        /// </summary>
        /// <response code="200">The updated balance.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to deposit.</param>
        /// <returns>The updated balance.</returns>
        [HttpPatch("Deposit")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DepositResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Deposit([FromForm][Required] DepositRequest request)
        {
            var input = new DepositInput(
                new AccountId(request.AccountId),
                new PositiveMoney(request.Amount));

            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
