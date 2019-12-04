namespace WebApi.UseCases.V1.Register
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using FluentMediator;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly RegisterPresenter _presenter;

        public CustomersController(
            IMediator mediator,
            RegisterPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Register a customer.
        /// </summary>
        /// <response code="200">The registered customer was create successfully.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to register a customer.</param>
        /// <returns>The newly registered customer.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromForm][Required] RegisterRequest request)
        {
            var input = new RegisterInput(
                new SSN(request.SSN),
                new PositiveMoney(request.InitialAmount));
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
