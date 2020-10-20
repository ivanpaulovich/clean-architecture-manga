namespace WebApi.UseCases.V1.Transactions.Withdraw
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.Withdraw;
    using Domain;
    using Domain.Debits;
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
    [FeatureGate(CustomFeature.Withdraw)]
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

        void IOutputPort.OutOfFunds()
        {
            Dictionary<string, string[]> messages = new Dictionary<string, string[]> {{"", new[] {"Out of funds."}}};

            ValidationProblemDetails problemDetails = new ValidationProblemDetails(messages);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._notification.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Debit debit, Account account) =>
            this._viewModel = this.Ok(new WithdrawResponse(new DebitModel(debit)));

        /// <summary>
        ///     Withdraw on an account.
        /// </summary>
        /// <response code="200">The updated balance.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="useCase"></param>
        /// <param name="accountId"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <returns>The updated balance.</returns>
        [Authorize]
        [HttpPatch("{accountId:guid}/Withdraw")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WithdrawResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Patch))]
        public async Task<IActionResult> Withdraw(
            [FromServices] IWithdrawUseCase useCase,
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
