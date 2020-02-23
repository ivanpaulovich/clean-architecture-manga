namespace WebApi.UseCases.V1.Deposit
{
    using Application.Boundaries.Deposit;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DepositPresenter : IOutputPort
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void NotFound(string message)
        {
            this.ViewModel = new NotFoundObjectResult(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depositOutput"></param>
        public void Standard(DepositOutput depositOutput)
        {
            var depositResponse = new DepositResponse(
                depositOutput.Transaction.Amount.ToMoney().ToDecimal(),
                depositOutput.Transaction.Description,
                depositOutput.Transaction.TransactionDate,
                depositOutput.UpdatedBalance.ToDecimal());
            this.ViewModel = new ObjectResult(depositResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }
    }
}
