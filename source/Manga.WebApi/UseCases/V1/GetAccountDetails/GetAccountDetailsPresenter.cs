namespace Manga.WebApi.UseCases.V1.GetAccountDetails
{
    using System.Collections.Generic;
    using Manga.Application.Boundaries.GetAccountDetails;
    using Manga.WebApi.Models;
    using Microsoft.AspNetCore.Mvc;

    public sealed class GetAccountDetailsPresenter : IOutputPort
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

        public void Default(GetAccountDetailsOutput output)
        {
            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in output.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            ViewModel = new OkObjectResult(new GetAccountDetailsResponse(
                output.AccountId,
                output.CurrentBalance,
                transactions));
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}