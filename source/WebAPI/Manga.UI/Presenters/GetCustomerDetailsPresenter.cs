namespace Manga.UI.Presenters
{
    using Manga.Application;
    using Manga.Application.Responses;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class GetCustomerDetailsPresenter : IOutputBoundary<CustomerResponse>
    {
        public IActionResult ViewModel { get; private set; }
        public CustomerResponse Response { get; private set; }

        public void Populate(CustomerResponse response)
        {
            Response = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            List<dynamic> accounts = new List<dynamic>();

            foreach (var account in response.Accounts)
            {
                List<dynamic> transactions = new List<dynamic>();

                foreach (var item in account.Transactions)
                {
                    var transaction = new
                    {
                        Amount = item.Amount,
                        Description = item.Description,
                        TransactionDate = item.TransactionDate
                    };

                    transactions.Add(transaction);
                }

                accounts.Add(new
                {
                    AccountId = account.AccountId,
                    CurrentBalance = account.CurrentBalance,
                    Transactions = account.Transactions
                });
            }

            ViewModel = new ObjectResult(new
            {
                CustomerId = response.CustomerId,
                Personnummer = response.Personnummer,
                Name = response.Name,
                Accounts = accounts
            });
        }
    }
}
