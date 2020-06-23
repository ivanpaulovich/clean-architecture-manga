namespace WebApi.UseCases.V1.Withdraw
{
    using Application.Boundaries.Withdraw;
    using Domain.Accounts.Debits;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    /// <summary>
    ///     Withdraw Presenter.
    /// </summary>
    public sealed class WithdrawPresenter : IWithdrawOutputPort
    {
        /// <summary>
        /// </summary>
        /// <value></value>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void OutOfBalance(string message) => this.ViewModel = new BadRequestObjectResult(message);

        /// <summary>
        /// </summary>
        /// <param name="output"></param>
        public void Standard(WithdrawOutput output)
        {
            var debitModel = new DebitModel((Debit)output.Transaction);
            var withdrawResponse = new WithdrawResponse(
                debitModel,
                output.UpdatedBalance.ToDecimal());
            this.ViewModel = new ObjectResult(withdrawResponse);
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
