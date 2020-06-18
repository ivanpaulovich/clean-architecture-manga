namespace WebApi.UseCases.V1.Withdraw
{
    using Application.Boundaries.Withdraw;
    using Domain.Accounts.Debits;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    /// <summary>
    /// </summary>
    public sealed class WithdrawPresenter : IWithdrawOutputPort
    {
        /// <summary>
        /// </summary>
        /// <value></value>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        public void OutOfBalance(string message) => this.ViewModel = new BadRequestObjectResult(message);

        public void Standard(WithdrawOutput output)
        {
            var debitModel = new DebitModel((Debit)output.Transaction);
            var withdrawResponse = new WithdrawResponse(
                debitModel,
                output.UpdatedBalance.ToDecimal());
            this.ViewModel = new ObjectResult(withdrawResponse);
        }

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
