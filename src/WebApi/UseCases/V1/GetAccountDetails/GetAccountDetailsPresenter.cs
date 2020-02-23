namespace WebApi.UseCases.V1.GetAccountDetails
{
    using System.Collections.Generic;
    using Application.Boundaries.GetAccountDetails;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    /// <summary>
    /// 
    /// </summary>
    public sealed class GetAccountDetailsPresenter : IOutputPort
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void NotFound(string message)
        {
            this.ViewModel = new NotFoundObjectResult(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getAccountDetailsOutput"></param>
        public void Standard(GetAccountDetailsOutput getAccountDetailsOutput)
        {
            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in getAccountDetailsOutput.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            var getAccountDetailsResponse = new GetAccountDetailsResponse(
                getAccountDetailsOutput.AccountId,
                getAccountDetailsOutput.CurrentBalance,
                transactions);

            this.ViewModel = new OkObjectResult(getAccountDetailsResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }
    }
}
