namespace WebApi.UseCases.V1.Withdraw
{
    using Application.Boundaries.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public sealed class WithdrawPresenter : IOutputPort
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            this.ViewModel = new NotFoundObjectResult(message);
        }

        public void OutOfBalance(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }

        public void Standard(WithdrawOutput withdrawOutput)
        {
            var withdrawResponse = new WithdrawResponse(
                withdrawOutput.Transaction.Amount.ToMoney().ToDecimal(),
                withdrawOutput.Transaction.Description,
                withdrawOutput.Transaction.TransactionDate,
                withdrawOutput.UpdatedBalance.ToDecimal());
            this.ViewModel = new ObjectResult(withdrawResponse);
        }

        public void WriteError(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }
    }
}
