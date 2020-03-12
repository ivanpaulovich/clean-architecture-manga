namespace WebApi.UseCases.V1.Transfer
{
    using Application.Boundaries.Transfer;
    using Microsoft.AspNetCore.Mvc;

    public sealed class TransferPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            this.ViewModel = new NotFoundObjectResult(message);
        }

        public void Standard(TransferOutput transferOutput)
        {
            var transferResponse = new
            {
                transferOutput.Transaction.Amount,
                transferOutput.Transaction.Description,
                transferOutput.Transaction.TransactionDate,
                transferOutput.UpdatedBalance
            };
            this.ViewModel = new ObjectResult(transferResponse);
        }

        public void WriteError(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }
    }
}
