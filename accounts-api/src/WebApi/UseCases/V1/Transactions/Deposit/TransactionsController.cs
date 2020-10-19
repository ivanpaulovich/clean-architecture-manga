namespace WebApi.UseCases.V1.Transactions.Deposit
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.Deposit;
    using Domain;
    using Domain.Credits;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common;
    using Modules.Common.FeatureFlags;
    using ViewModels;

    /// <summary>
    ///     Accounts
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.Deposit)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class TransactionsController : ControllerBase, IOutputPort
    {
        private readonly Notification _notification;

        public TransactionsController(Notification notification)
        {
            this._notification = notification;
        }

        private IActionResult? _viewModel;

        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._notification.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Credit credit, Account account) =>
            this._viewModel = this.Ok(new DepositResponse(new CreditModel(credit)));

        /// <summary>
        ///     Deposit on an account.
        /// </summary>
        /// <response code="200">The transaction details.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="useCase">Use case.</param>
        /// <param name="accountId">Account Id.</param>
        /// <param name="amount">Amount.</param>
        /// <param name="currency">Currency.</param>
        /// <returns>The Transaction.</returns>
        [Authorize]
        [HttpPatch("{accountId:guid}/Deposit")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DepositResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Patch))]
        public async Task<IActionResult> Deposit(
            [FromServices] IDepositUseCase useCase,
            [FromRoute] [Required] Guid accountId,
            [FromForm] [Required] decimal amount,
            [FromForm] [Required] string currency)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(accountId, amount, currency)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
