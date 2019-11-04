namespace WebApi.UseCases.V1.GetCustomerDetails
{
    using System.Collections.Generic;
    using Application.Boundaries.GetCustomerDetails;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public sealed class GetCustomerDetailsPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void Standard(GetCustomerDetailsOutput getCustomerDetailsOutput)
        {
            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();

            foreach (var account in getCustomerDetailsOutput.Accounts)
            {
                List<TransactionModel> transactions = new List<TransactionModel>();

                foreach (var item in account.Transactions)
                {
                    var transaction = new TransactionModel(
                        item.Amount.ToMoney().ToDecimal(),
                        item.Description,
                        item.TransactionDate);

                    transactions.Add(transaction);
                }

                accounts.Add(new AccountDetailsModel(
                    account.AccountId,
                    account.CurrentBalance.ToDecimal(),
                    transactions));
            }

            var getCustomerDetailsResponse = new GetCustomerDetailsResponse(
                getCustomerDetailsOutput.CustomerId,
                getCustomerDetailsOutput.SSN.ToString(),
                getCustomerDetailsOutput.Name.ToString(),
                accounts
            );

            ViewModel = new OkObjectResult(getCustomerDetailsResponse);
        }
    }
}