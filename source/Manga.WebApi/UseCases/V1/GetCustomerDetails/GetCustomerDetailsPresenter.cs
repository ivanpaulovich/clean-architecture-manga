namespace Manga.WebApi.UseCases.V1.GetCustomerDetails
{
    using System.Collections.Generic;
    using Manga.Application.Boundaries.GetCustomerDetails;
    using Manga.WebApi.Models;
    using Microsoft.AspNetCore.Mvc;

    public sealed class GetCustomerDetailsPresenter : IOutputPort
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

        public void Default(GetCustomerDetailsOutput output)
        {
            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();

            foreach (var account in output.Accounts)
            {
                List<TransactionModel> transactions = new List<TransactionModel>();

                foreach (var item in account.Transactions)
                {
                    var transaction = new TransactionModel(
                        item.Amount,
                        item.Description,
                        item.TransactionDate);

                    transactions.Add(transaction);
                }

                accounts.Add(new AccountDetailsModel(
                    account.AccountId,
                    account.CurrentBalance,
                    transactions));
            }

            GetCustomerDetailsResponse model = new GetCustomerDetailsResponse(
                output.CustomerId,
                output.SSN,
                output.Name,
                accounts
            );

            ViewModel = new OkObjectResult(model);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}