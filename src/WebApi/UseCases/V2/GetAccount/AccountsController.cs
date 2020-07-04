namespace WebApi.UseCases.V2.GetAccount
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.GetAccount;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common.FeatureFlags;

    /// <summary>
    ///     Accounts
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [FeatureGate(CustomFeature.GetAccountDetailsV2)]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        /// <summary>
        ///     Get an account details.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="presenter"></param>
        /// <param name="request">A <see cref="GetAccountDetailsRequestV2"></see>.</param>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [Authorize]
        [HttpGet("{AccountId:guid}", Name = "GetAccountV2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator,
            [FromServices] GetAccountDetailsPresenterV2 presenter,
            [FromRoute][Required] GetAccountDetailsRequestV2 request)
        {
            var input = new GetAccountInput(request.AccountId);
            await mediator.PublishAsync(input, "GetAccountDetailsV2")
                .ConfigureAwait(false);
            return presenter.ViewModel;
        }
    }
}
