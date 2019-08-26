namespace Manga.WebApi.UseCases.V1.Register
{
    using System.Collections.Generic;
    using Manga.Application.Boundaries.Register;
    using Manga.WebApi.Models;
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
            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in output.Account.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            AccountDetailsModel account = new AccountDetailsModel(
                output.Account.AccountId,
                output.Account.CurrentBalance,
                transactions);

            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();
            accounts.Add(account);

            RegisterResponse model = new RegisterResponse(
                output.Customer.CustomerId,
                output.Customer.SSN,
                output.Customer.Name,
                accounts
            );

            ViewModel = new CreatedAtRouteResult("GetCustomer",
                new
                {
                    customerId = model.CustomerId
                },
                model);
        }
    }
}