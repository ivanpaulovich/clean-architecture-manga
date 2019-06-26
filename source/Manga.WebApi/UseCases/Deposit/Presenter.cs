namespace Manga.WebApi.UseCases.Deposit
{
    using Manga.Application.Boundaries.Deposit;
    using Microsoft.AspNetCore.Mvc;

    public sealed class Presenter : IOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            ViewModel = new NoContentResult();
        }

        public void Handle(Output output)
        {
            ViewModel = new ObjectResult(new CurrentAccountBalanceModel(
                output.Transaction.Amount,
                output.Transaction.Description,
                output.Transaction.TransactionDate,
                output.UpdatedBalance
            ));
        }
    }
}