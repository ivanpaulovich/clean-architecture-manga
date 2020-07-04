namespace WebApi.UseCases.V1.Transfer
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.Transfer;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common.FeatureFlags;
    using WebApi.Modules.Common;

    /// <summary>
    ///     Accounts
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [FeatureGate(CustomFeature.Transfer)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        /// <summary>
        ///     Transfer to an account.
        /// </summary>
        /// <response code="200">The updated balance.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="mediator"></param>
        /// <param name="presenter"></param>
        /// <param name="request">The request to Transfer.</param>
        /// <returns>The updated balance.</returns>
        [Authorize]
        [HttpPatch("Transfer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransferResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Patch))]
        public async Task<IActionResult> Transfer(
            [FromServices] IMediator mediator,
            [FromServices] TransferPresenter presenter,
            [FromForm][Required] TransferRequest request)
        {
            var input = new TransferInput(
                request.OriginAccountId,
                request.DestinationAccountId,
                request.Amount);

            await mediator.PublishAsync(input)
                .ConfigureAwait(false);

            return presenter.ViewModel!;
        }
    }
}
