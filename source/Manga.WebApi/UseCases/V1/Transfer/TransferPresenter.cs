namespace Manga.WebApi.UseCases.V1.Transfer
{
    using Manga.Application.Boundaries.Transfer;
    using Microsoft.AspNetCore.Mvc;

    public sealed class TransferPresenter : IOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void Handle(TransferOutput output)
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