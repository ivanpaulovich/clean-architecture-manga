namespace Manga.MvcApp.UseCases.GetCustomer
{
    using Manga.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public sealed class Presenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(CustomerOutput output, Controller controller)
        {
            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();

            foreach (var account in output.Accounts)
            {
                accounts.Add(new AccountDetailsModel(
                    account.AccountId,
                    account.CurrentBalance));
            }

            CustomerDetailsModel model = new CustomerDetailsModel(
                output.CustomerId,
                output.Personnummer,
                output.Name,
                accounts
            );

            ViewModel = controller.View(model);
        }
    }
}
