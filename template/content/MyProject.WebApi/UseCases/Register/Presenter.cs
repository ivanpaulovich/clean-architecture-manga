namespace MyProject.WebApi.UseCases.Register
{
    using MyProject.Application;
    using MyProject.Application.UseCases.Register;
    using MyProject.WebApi.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class Presenter : IOutputBoundary<RegisterOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public RegisterOutput Output { get; private set; }

        public void Populate(RegisterOutput response)
        {
            Output = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }
            
            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in response.Account.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            AccountDetailsModel account = new AccountDetailsModel(
                response.Account.AccountId,
                response.Account.CurrentBalance,
                transactions);

            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();
            accounts.Add(account);

            Model model = new Model(
                response.Customer.CustomerId,
                response.Customer.Personnummer,
                response.Customer.Name,
                accounts
            );

            ViewModel = new CreatedAtRouteResult("GetCustomer", new { customerId = model.CustomerId }, model);
        }
    }
}
