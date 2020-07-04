namespace WebApi.UseCases.V1.GetCustomer
{
    using System.Threading.Tasks;
    using Application.Boundaries.GetCustomer;
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
    public sealed class CustomersController : ControllerBase
    {
        /// <summary>
        ///     Get the Customer details.
        /// </summary>
        /// <response code="200">The Customer.</response>
        /// <response code="404">Not Found.</response>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [Authorize]
        [HttpGet(Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCustomerDetailsResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Get))]
        public async Task<IActionResult> GetCustomer(
            [FromServices] IMediator mediator,
            [FromServices] GetCustomerDetailsPresenter presenter)
        {
            var input = new GetCustomerInput();

            await mediator.PublishAsync(input)
                .ConfigureAwait(false);

            return presenter.ViewModel!;
        }
    }
}
