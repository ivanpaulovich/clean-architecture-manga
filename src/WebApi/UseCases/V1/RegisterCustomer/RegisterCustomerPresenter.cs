namespace WebApi.UseCases.V1.RegisterCustomer
{
    using System.Collections.Generic;
    using Application.Boundaries.RegisterCustomer;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public sealed class RegisterCustomerPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Standard(RegisterCustomerOutput output)
        {
            var transactions = new List<TransactionModel>();

            foreach (var item in output.Account.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount.ToMoney().ToDecimal(),
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            var account = new AccountDetailsModel(
                output.Account.AccountId,
                output.Account.CurrentBalance.ToDecimal(),
                transactions);

            var accounts = new List<AccountDetailsModel> {account};

            var registerResponse = new RegisterCustomerResponse(
                output.Customer.CustomerId,
                output.Customer.SSN.ToString(),
                output.Customer.Name.ToString(),
                output.Customer.Username.ToString(),
                accounts
            );

            ViewModel = new CreatedAtRouteResult("GetCustomer",
                new
                {
                    customerId = registerResponse.CustomerId
                },
                registerResponse);
        }
    }
}
