namespace WebApi.UseCases.V1.Transfer
{
    using Application.Boundaries.Transfer;
    using Domain.Accounts.Debits;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    /// <summary>
    /// </summary>
    public sealed class TransferPresenter : ITransferOutputPort
    {
        /// <summary>
        /// </summary>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        /// </summary>
        /// <param name="output"></param>
        public void Standard(TransferOutput output)
        {
            var transactionModel = new DebitModel((Debit)output.Transaction);
            var transferResponse = new TransferResponse(transactionModel, output.UpdatedBalance.ToDecimal());
            this.ViewModel = new ObjectResult(transferResponse);
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
