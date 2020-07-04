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
        /// ViewModel result.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult? ViewModel { get; private set; }

        /// <summary>
        /// Not found result.
        /// </summary>
        /// <param name="message">Message.</param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        /// Out of balances result.
        /// </summary>
        /// <param name="message">Output.</param>
        public void OutOfBalance(string message) => this.ViewModel = new BadRequestObjectResult(message);

        /// <summary>
        /// Standard.
        /// </summary>
        /// <param name="output">Output.</param>
        public void Standard(WithdrawOutput output)
        {
            var debitModel = new DebitModel((Debit)output.Transaction);
            var withdrawResponse = new WithdrawResponse(
                debitModel,
                output.UpdatedBalance.ToDecimal());
            this.ViewModel = new ObjectResult(withdrawResponse);
        }

        /// <summary>
        /// An error happenend.
        /// </summary>
        /// <param name="message">Message.</param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
