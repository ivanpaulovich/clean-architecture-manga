namespace WebApi.UseCases.V1.Register
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Modules.Common;

    /// <summary>
    ///     Customers
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
        ///     Register a customer.
        /// </summary>
        /// <response code="200">Customer already exists.</response>
        /// <response code="201">The registered customer was created successfully.</response>
        /// <response code="400">Bad request.</response>
        /// <param name="mediator">Mediator.</param>
        /// <param name="presenter">Presenter.</param>
        /// <param name="request">The request to register a customer.</param>
        /// <returns>The newly registered customer.</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RegisterResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Post))]
        public async Task<IActionResult> Post(
            [FromServices] IMediator mediator,
            [FromServices] RegisterPresenter presenter,
            [FromForm][Required] RegisterRequest request)
        {
            var input = new RegisterInput(
                request.SSN,
                request.InitialAmount);

            await mediator.PublishAsync(input)
                .ConfigureAwait(false);

            return presenter.ViewModel!;
        }
    }
}
