namespace Manga.UI.Presenters
{
    using Manga.Application;
    using Manga.Application.Responses;
    using Manga.UI.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class CustomerDetailsPresenter : IOutputBoundary<CustomerResponse>
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

            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();

            foreach (var account in response.Accounts)
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

            CustomerDetailsModel model = new CustomerDetailsModel(
                response.CustomerId,
                response.Personnummer,
                response.Name,
                accounts
            );

            ViewModel = new ObjectResult(model);
        }
    }
}
