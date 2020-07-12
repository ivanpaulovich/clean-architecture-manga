namespace WebApi.UseCases.V1.Accounts.GetAccount
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.GetAccount;
    using Domain.Accounts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Modules.Common;

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
    public sealed class AccountsController : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        void IOutputPort.Invalid(Notification notification)
        {
            var problemDetails = new ValidationProblemDetails(notification.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Account account) => this._viewModel = this.Ok(new GetAccountResponse(account));

        /// <summary>
        ///     Get an account details.
        /// </summary>
        /// <response code="200">The Account.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="useCase">Use case.</param>
        /// <param name="accountId"></param>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [Authorize]
        [HttpGet("{accountId:guid}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public async Task<IActionResult> Get(
            [FromServices] IGetAccountUseCase useCase,
            [FromRoute] [Required] Guid accountId)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(new GetAccountInput(accountId))
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
