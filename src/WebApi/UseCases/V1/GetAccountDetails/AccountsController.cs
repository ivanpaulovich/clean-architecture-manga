namespace WebApi.UseCases.V1.GetAccountDetails
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.GetAccountDetails;
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
        private readonly GetAccountDetailsPresenter _presenter;

        public AccountsController(
            IMediator mediator,
            GetAccountDetailsPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Get an account details.
        /// </summary>
        /// <param name="request">A <see cref="GetAccountDetailsRequest"></see>.</param>
        /// <returns>An asynchronous <see cref="IActionResult"/>.</returns>
        [HttpGet("{AccountId}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountDetailsResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute][Required] GetAccountDetailsRequest request)
        {
            var input = new GetAccountDetailsInput(new AccountId(request.AccountId));
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
