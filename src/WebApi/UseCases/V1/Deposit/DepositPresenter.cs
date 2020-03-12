namespace WebApi.UseCases.V1.Deposit
{
    using Application.Boundaries.Deposit;
    using Microsoft.AspNetCore.Mvc;

    public sealed class DepositPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            this.ViewModel = new NotFoundObjectResult(message);
        }

        public void Standard(DepositOutput depositOutput)
        {
            var depositResponse = new DepositResponse(
                depositOutput.Transaction.Amount.ToMoney().ToDecimal(),
                depositOutput.Transaction.Description,
                depositOutput.Transaction.TransactionDate,
                depositOutput.UpdatedBalance.ToDecimal());
            this.ViewModel = new ObjectResult(depositResponse);
        }

        public void WriteError(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }
    }
}
