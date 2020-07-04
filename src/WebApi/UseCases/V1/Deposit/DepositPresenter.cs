namespace WebApi.UseCases.V1.Deposit
{
    using Application.Boundaries.Deposit;
    using Domain.Accounts.Credits;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Generates Deposit presentations.
    /// </summary>
    public sealed class DepositPresenter : IDepositOutputPort
    {
        /// <summary>
        /// ViewModel result.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult? ViewModel { get; private set; }

        /// <summary>
        /// Account not found.
        /// </summary>
        /// <param name="message">Message.</param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        /// Standard.
        /// </summary>
        /// <param name="output">Output.</param>
        public void Standard(DepositOutput output)
        {
            var depositEntity = (Credit)output.Transaction;
            var depositResponse = new DepositResponse(
                depositEntity.Amount.ToMoney().ToDecimal(),
                Credit.Description,
                depositEntity.TransactionDate,
                output.UpdatedBalance.ToDecimal());
            this.ViewModel = new ObjectResult(depositResponse);
        }

        /// <summary>
        /// An error happened.
        /// </summary>
        /// <param name="message">Message.</param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
