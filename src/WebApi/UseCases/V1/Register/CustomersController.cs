namespace WebApi.UseCases.V1.Register
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

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
        /// <response code="200">The registered customer was create successfully.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="mediator"></param>
        /// <param name="presenter"></param>
        /// <param name="request">The request to register a customer.</param>
        /// <returns>The newly registered customer.</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(
            [FromServices] IMediator mediator,
            [FromServices] RegisterPresenter presenter,
            [FromForm] [Required] RegisterRequest request)
        {
            var input = new RegisterInput(
                request.SSN,
                request.InitialAmount);

            await mediator.PublishAsync(input)
                .ConfigureAwait(false);

            return presenter.ViewModel;
        }
    }
}
