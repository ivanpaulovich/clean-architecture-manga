namespace Manga.WebApi.UseCases.V1.GetCustomerDetails
{
    using System.Collections.Generic;
    using Manga.Application.Boundaries.GetCustomerDetails;
    using Manga.WebApi.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public sealed class GetCustomerDetailsPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Standard(GetCustomerDetailsOutput getCustomerDetailsOutput)
        {
            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();

            foreach (var account in getCustomerDetailsOutput.Accounts)
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

            var getCustomerDetailsResponse = new GetCustomerDetailsResponse(
                getCustomerDetailsOutput.CustomerId,
                getCustomerDetailsOutput.SSN,
                getCustomerDetailsOutput.Name,
                accounts
            );

            ViewModel = new OkObjectResult(getCustomerDetailsResponse);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}
