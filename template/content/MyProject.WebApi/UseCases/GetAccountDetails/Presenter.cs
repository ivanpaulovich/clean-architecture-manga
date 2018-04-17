namespace MyProject.WebApi.UseCases.GetAccountDetails
{
    using MyProject.Application;
    using MyProject.Application.Outputs;
    using MyProject.WebApi.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class Presenter : IOutputBoundary<AccountOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public AccountOutput Output { get; private set; }

        public void Populate(AccountOutput output)
        {
            Output = output;

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
