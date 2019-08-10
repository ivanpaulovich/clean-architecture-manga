namespace Manga.WebApi.UseCases.Transfer
{
    using Manga.Application.Boundaries.Transfer;
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
            ViewModel = new ObjectResult(new
            {
                Amount = output.Transaction.Amount,
                Description = output.Transaction.Description,
                TransactionDate = output.Transaction.TransactionDate,
                UpdatedBalance = output.UpdatedBalance,
            });
        }
    }
}