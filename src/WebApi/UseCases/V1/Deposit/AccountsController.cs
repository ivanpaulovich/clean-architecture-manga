namespace WebApi.UseCases.V1.Deposit
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Modules.Common;

    /// <summary>
    ///     Accounts
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        /// <summary>
        ///     Deposit on an account.
        /// </summary>
        /// <response code="200">The updated balance.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="mediator">Mediator.</param>
        /// <param name="presenter">Presenter.</param>
        /// <param name="request">The request to deposit.</param>
        /// <returns>The updated balance.</returns>
        [Authorize]
        [HttpPatch("Deposit")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DepositResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Patch))]
        public async Task<IActionResult> Deposit(
            [FromServices] IMediator mediator, [FromServices] DepositPresenter presenter,
            [FromForm][Required] DepositRequest request)
        {
            var input = new DepositInput(
                request.AccountId,
                request.Amount,
                request.Currency);

            await mediator.PublishAsync(input)
                .ConfigureAwait(false);

            return presenter.ViewModel!;
        }
    }
}
