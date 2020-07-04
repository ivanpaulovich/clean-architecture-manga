namespace WebApi.UseCases.V1.GetAccount
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.GetAccount;
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
        ///     Get an account details.
        /// </summary>
        /// <response code="200">The Account.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="mediator">Mediator.</param>
        /// <param name="presenter">Presenter.</param>
        /// <param name="request">A <see cref="GetAccountRequest"></see>.</param>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [Authorize]
        [HttpGet("{AccountId:guid}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator,
            [FromServices] GetAccountPresenter presenter,
            [FromRoute][Required] GetAccountRequest request)
        {
            var input = new GetAccountInput(request.AccountId);

            await mediator.PublishAsync(input)
                .ConfigureAwait(false);

            return presenter.ViewModel!;
        }
    }
}
