namespace WebApi.UseCases.V2.GetAccountDetails
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.GetAccountDetails;
    using Domain.Accounts.ValueObjects;
    using FluentMediator;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.FeatureFlags;

    [FeatureGate(Feature.GetAccountDetailsV2)]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
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
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator,
            [FromServices] GetAccountDetailsPresenterV2 presenter,
            [FromRoute] [Required] GetAccountDetailsRequestV2 request)
        {
            var input = new GetAccountDetailsInput(new AccountId(request.AccountId));
            await mediator.PublishAsync(input, "GetAccountDetailsV2");
            return presenter.ViewModel;
        }
    }
}
