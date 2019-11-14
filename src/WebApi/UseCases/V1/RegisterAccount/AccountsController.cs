namespace WebApi.UseCases.V1.RegisterAccount
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.RegisterAccount;
    using Domain.ValueObjects;
    using FluentMediator;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly RegisterAccountPresenter _presenter;

        public AccountsController(
            IMediator mediator,
            RegisterAccountPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Register an account
        /// </summary>
        /// <response code="201">The registered account was create successfully.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to register an account</param>
        /// <returns>The newly registered account</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RegisterAccountResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody][Required] RegisterAccountRequest request)
        {
            var input = new RegisterAccountInput(
                new SSN(request.SSN),
                new Name(request.Name),
                new PositiveMoney(request.InitialAmount)
            );
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
