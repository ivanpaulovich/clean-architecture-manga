namespace WebApi.UseCases.V1.CloseAccount
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.CloseAccount;
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
        ///     Close an Account.
        /// </summary>
        /// <response code="200">The closed account id.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="mediator">Mediator.</param>
        /// <param name="presenter">Presenter.</param>
        /// <param name="request">The request to Close an Account.</param>
        /// <returns>ViewModel.</returns>
        [Authorize]
        [HttpDelete("{AccountId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CloseAccountResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<IActionResult> Close(
            [FromServices] IMediator mediator,
            [FromServices] CloseAccountPresenter presenter,
            [FromRoute][Required] CloseAccountRequest request)
        {
            var input = new CloseAccountInput(request.AccountId);

            await mediator.PublishAsync(input)
                .ConfigureAwait(false);

            return presenter.ViewModel!;
        }
    }
}
