namespace WebApi.UseCases.V1.GetAccounts
{
    using System.Threading.Tasks;
    using Application.Boundaries.GetAccounts;
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
        ///     Get Accounts.
        /// </summary>
        /// <response code="200">The List of Accounts.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="mediator">Mediator.</param>
        /// <param name="presenter">Presenter.</param>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountsResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator,
            [FromServices] GetAccountsPresenter presenter)
        {
            var input = new GetAccountsInput();

            await mediator.PublishAsync(input)
                .ConfigureAwait(false);

            return presenter.ViewModel!;
        }
    }
}
