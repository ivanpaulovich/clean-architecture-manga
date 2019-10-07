namespace Manga.WebApi.UseCases.V1.Deposit
{
    using Manga.Application.Boundaries.Deposit;
    using Microsoft.AspNetCore.Mvc;

    public sealed class DepositPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Standard(DepositOutput depositOutput)
        {
            var depositResponse = new DepositResponse(
                depositOutput.Transaction.Amount,
                depositOutput.Transaction.Description,
                depositOutput.Transaction.TransactionDate,
                depositOutput.UpdatedBalance
            );
            ViewModel = new ObjectResult(depositResponse);
        }
    }
}
