namespace WebApi.UseCases.V1.Authenticate
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.Authenticate;
    using Domain.ValueObjects;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public sealed class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AuthenticatePresenter _presenter;
        private readonly IConfiguration _configuration;

        public CustomersController(
            IMediator mediator,
            AuthenticatePresenter presenter,
            IConfiguration configuration)
        {
            _mediator = mediator;
            _presenter = presenter;
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticate a Customer
        /// </summary>
        /// <response code="200">The user with its JWT Token</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticateResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Authenticate([FromBody][Required] AuthenticateRequest request)
        {
            var jwtSecret = _configuration.GetSection("Authentication")["JwtSecret"];
            var input = new AuthenticateInput(
                new Username(request.Username),
                new Password(request.Password),
                jwtSecret);
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
