namespace WebApi.UseCases.V1.Transactions.Withdraw
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.Withdraw;
    using Domain.Accounts;
    using Domain.Accounts.Debits;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Modules.Common;
    using ViewModels;

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
    public sealed class TransactionsController : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        public void OutOfFunds() => this._viewModel = this.BadRequest("Out of funds.");

        void IOutputPort.Invalid(Notification notification)
        {
            var problemDetails = new ValidationProblemDetails(notification.ModelState);
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

            await useCase.Execute(new WithdrawInput(accountId, amount, currency))
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
