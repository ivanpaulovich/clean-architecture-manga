namespace WebApi.UseCases.V1.Transfer
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.Transfer;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using FluentMediator;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using WebApi.DependencyInjection.FeatureFlags;

    [FeatureGate(Features.Transfer)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly TransferPresenter _presenter;

        public AccountsController(
            IMediator mediator,
            TransferPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Transfer to an account.
        /// </summary>
        /// <response code="200">The updated balance.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to Transfer.</param>
        /// <returns>The updated balance.</returns>
        [HttpPatch("Transfer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransferResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Transfer([FromForm][Required] TransferRequest request)
        {
            var input = new TransferInput(
                new AccountId(request.OriginAccountId),
                new AccountId(request.DestinationAccountId),
                new PositiveMoney(request.Amount));

            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
