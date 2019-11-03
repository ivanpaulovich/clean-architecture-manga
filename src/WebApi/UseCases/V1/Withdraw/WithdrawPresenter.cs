namespace WebApi.UseCases.V1.Withdraw
{
    using Application.Boundaries.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    public sealed class WithdrawPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void OutOfBalance(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }

        public void Standard(WithdrawOutput withdrawOutput)
        {
            var withdrawResponse = new WithdrawResponse(
                withdrawOutput.Transaction.Amount.ToMoney().ToDecimal(),
                withdrawOutput.Transaction.Description,
                withdrawOutput.Transaction.TransactionDate,
                withdrawOutput.UpdatedBalance.ToDecimal()
            );
            ViewModel = new ObjectResult(withdrawResponse);
        }
    }
}