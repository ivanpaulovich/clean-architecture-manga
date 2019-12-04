namespace WebApi.UseCases.V1.CloseAccount
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.CloseAccount;
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
        private readonly CloseAccountPresenter _presenter;

        public AccountsController(
            IMediator mediator,
            CloseAccountPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Close an Account.
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
            var input = new CloseAccountInput(new AccountId(request.AccountId));
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
