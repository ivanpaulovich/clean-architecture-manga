namespace WebApi.UseCases.V1.Accounts.CloseAccount
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.CloseAccount;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common;
    using Modules.Common.FeatureFlags;

    /// <summary>
    ///     Accounts
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.CloseAccount)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase, IOutputPort
    {
        private readonly ICloseAccountUseCase _useCase;
        private readonly Notification _notification;

        public AccountsController(ICloseAccountUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        private IActionResult? _viewModel;

        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._notification.ModelState);
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
        /// <param name="accountId">The AccountId.</param>
        /// <returns>ViewModel.</returns>
        [Authorize]
        [HttpDelete("{accountId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CloseAccountResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<IActionResult> Close(
            [FromRoute] [Required] Guid accountId)
        {
            this._useCase.SetOutputPort(this);

            await this._useCase.Execute(accountId)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
