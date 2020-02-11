namespace WebApi.UseCases.V2.GetAccountDetails
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.GetAccountDetails;
    using DependencyInjection.FeatureFlags;
    using Domain.Accounts.ValueObjects;
    using FluentMediator;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;

    [FeatureGate(Features.GetAccountDetailsV2)]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly GetAccountDetailsPresenterV2 _presenter;

        public AccountsController(
            IMediator mediator,
            GetAccountDetailsPresenterV2 presenter)
        {
            this._mediator = mediator;
            this._presenter = presenter;
        }

        /// <summary>
        ///     Get an account details.
        /// </summary>
        /// <param name="request">A <see cref="GetAccountDetailsRequestV2"></see>.</param>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [HttpGet("{AccountId}", Name = "GetAccountV2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] [Required] GetAccountDetailsRequestV2 request)
        {
            var input = new GetAccountDetailsInput(new AccountId(request.AccountId));
            await this._mediator.PublishAsync(input, "GetAccountDetailsV2");
            return this._presenter.ViewModel;
        }
    }
}
