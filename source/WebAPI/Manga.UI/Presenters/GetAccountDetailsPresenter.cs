namespace Manga.UI.Presenters
{
    using Manga.Application;
    using Manga.Application.Responses;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class GetAccountDetailsPresenter : IOutputBoundary<AccountResponse>
    {
        public IActionResult ViewModel { get; private set; }
        public AccountResponse Response { get; private set; }

        public void Populate(AccountResponse response)
        {
            Response = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            List<dynamic> transactions = new List<dynamic>();

            foreach (var item in response.Transactions)
            {
                var transaction = new
                {
                    Amount = item.Amount,
                    Description = item.Description,
                    TransactionDate = item.TransactionDate
                };

                transactions.Add(transaction);
            }

            ViewModel = new ObjectResult(new
            {
                AccountId = response.AccountId,
                CurrentBalance = response.CurrentBalance,
                CustomerId = response.CustomerId,
                Transactions = transactions
            });
        }
    }
}
