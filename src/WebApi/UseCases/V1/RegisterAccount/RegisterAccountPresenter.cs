namespace WebApi.UseCases.V1.RegisterAccount
{
    using System.Collections.Generic;
    using Application.Boundaries.RegisterAccount;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public sealed class RegisterAccountPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Standard(RegisterAccountOutput output)
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

            var accounts = new List<AccountDetailsModel>();
            accounts.Add(account);

            var registerResponse = new RegisterAccountResponse(
                output.Customer.CustomerId,
                output.Customer.SSN.ToString(),
                output.Customer.Name.ToString(),
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
