namespace WebApi.UseCases.V1.GetCustomerDetails
{
    using System.Collections.Generic;
    using Application.Boundaries.GetCustomerDetails;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public sealed class GetCustomerDetailsPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            this.ViewModel = new NotFoundObjectResult(message);
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
                accounts);

            this.ViewModel = new OkObjectResult(getCustomerDetailsResponse);
        }

        public void WriteError(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }
    }
}
