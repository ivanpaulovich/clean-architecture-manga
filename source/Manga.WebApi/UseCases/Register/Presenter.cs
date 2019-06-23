namespace Manga.WebApi.UseCases.Register
{
    using System.Collections.Generic;
    using Manga.Application.Boundaries.Register;
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

            CustomerModel model = new CustomerModel(
                output.Customer.CustomerId,
                output.Customer.SSN,
                output.Customer.Name,
                accounts
            );

            ViewModel = new CreatedAtRouteResult("GetCustomer",
                new { 
                    customerId = model.CustomerId 
                },
                model);
        }
    }
}