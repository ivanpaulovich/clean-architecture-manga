namespace Manga.WebApi.UseCases.Withdraw
{
    using Manga.Application.Boundaries.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    public sealed class Presenter : IOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(Output output)
        {
            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

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