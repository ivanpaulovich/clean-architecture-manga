namespace Manga.WebApi.UseCases.V1.Register
{
    using System.Collections.Generic;
    using Manga.Application.Boundaries.Register;
    using Manga.WebApi.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public sealed class RegisterPresenter : IOutputPort
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

        public void Standard(RegisterOutput output)
        {
            var transactions = new List<TransactionModel>();

            foreach (var item in output.Account.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            var account = new AccountDetailsModel(
                output.Account.AccountId,
                output.Account.CurrentBalance,
                transactions);

            var accounts = new List<AccountDetailsModel>();
            accounts.Add(account);

            var registerResponse = new RegisterResponse(
                output.Customer.CustomerId,
                output.Customer.SSN,
                output.Customer.Name,
                accounts
            );

            ViewModel = new CreatedAtRouteResult("GetCustomer",
                new
                {
                    customerId = registerResponse.CustomerId
                },
                registerResponse);
        }
    }
}