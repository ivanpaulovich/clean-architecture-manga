namespace Manga.WebApi.UseCases.V1.Withdraw
{
    using Manga.Application.Boundaries.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    public sealed class WithdrawPresenter : IOutputPort
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

        public void Default(WithdrawOutput output)
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