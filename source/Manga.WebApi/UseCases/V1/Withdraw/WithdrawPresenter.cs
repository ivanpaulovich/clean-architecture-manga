namespace Manga.WebApi.UseCases.V1.Withdraw
{
    using Manga.Application.Boundaries.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    public sealed class WithdrawPresenter : IOutputHandler
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

        public void Handle(WithdrawOutput output)
        {
            ViewModel = new ObjectResult(new WithdrawResponse(
                output.Transaction.Amount,
                output.Transaction.Description,
                output.Transaction.TransactionDate,
                output.UpdatedBalance
            ));
        }
    }
}