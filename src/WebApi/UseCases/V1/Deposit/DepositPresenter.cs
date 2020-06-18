namespace WebApi.UseCases.V1.Deposit
{
    using Application.Boundaries.Deposit;
    using Domain.Accounts.Credits;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// </summary>
    public sealed class DepositPresenter : IDepositOutputPort
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        /// </summary>
        /// <param name="output"></param>
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
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
