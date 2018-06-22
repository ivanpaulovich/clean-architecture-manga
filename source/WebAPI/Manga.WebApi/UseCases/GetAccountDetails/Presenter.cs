namespace Manga.WebApi.UseCases.GetAccountDetails
{
    using Manga.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public sealed class Presenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(AccountOutput output)
        {
            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in output.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            ViewModel = new ObjectResult(new AccountDetailsModel(
                output.AccountId,
                output.CurrentBalance,
                transactions));
        }
    }
}
