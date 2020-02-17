namespace WebApi.UseCases.V1.GetAccountDetails
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.GetAccountDetails;
    using Domain.Accounts.ValueObjects;
    using FluentMediator;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        /// <summary>
        ///     Get an account details.
        /// </summary>
        /// <param name="request">A <see cref="GetAccountDetailsRequest"></see>.</param>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [HttpGet("{AccountId}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountDetailsResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator,
            [FromServices] GetAccountDetailsPresenter presenter,
            [FromRoute] [Required] GetAccountDetailsRequest request)
        {
            var input = new GetAccountDetailsInput(new AccountId(request.AccountId));
            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }
    }
}
