namespace WebApi.UseCases.V1.Transfer
{
    using Application.Boundaries.Transfer;
    using Domain.Accounts.Debits;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public sealed class TransferPresenter : ITransferOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        public void Standard(TransferOutput transferOutput)
        {
            var transactionModel = new DebitModel((Debit)transferOutput.Transaction);
            var transferResponse = new TransferResponse(transactionModel, transferOutput.UpdatedBalance.ToDecimal());
            this.ViewModel = new ObjectResult(transferResponse);
        }

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
