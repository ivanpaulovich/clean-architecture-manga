namespace WebApi.UseCases.V1.Accounts.CloseAccount
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.CloseAccount;
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
    [Authorize]
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

        void IOutputPort.HasFunds() => this._viewModel = this.BadRequest("Account has funds.");

        void IOutputPort.Ok(Account account) => this._viewModel = this.Ok(new CloseAccountResponse(account));

        /// <summary>
        ///     Close an Account.
        /// </summary>
        /// <response code="200">The closed account id.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="useCase">Use case.</param>
        /// <param name="accountId">The AccountId.</param>
        /// <returns>ViewModel.</returns>
        [HttpDelete("{accountId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CloseAccountResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<IActionResult> Close(
            [FromServices] ICloseAccountUseCase useCase,
            [FromRoute] [Required] Guid accountId)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(new CloseAccountInput(accountId))
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
