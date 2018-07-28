namespace Manga.MvcApp.UseCases.GetAccount
{
    using Manga.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public sealed class Presenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(AccountOutput output, Controller controller)
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

            AccountDetailsModel account = new AccountDetailsModel(
                output.AccountId,
                output.CurrentBalance,
                transactions);

            ViewModel = controller.View(account);
        }
    }
}
