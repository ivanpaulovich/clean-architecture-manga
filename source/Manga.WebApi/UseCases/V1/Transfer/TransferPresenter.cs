namespace Manga.WebApi.UseCases.V1.Transfer
{
    using Manga.Application.Boundaries.Transfer;
    using Microsoft.AspNetCore.Mvc;

    public sealed class TransferPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Standard(TransferOutput transferOutput)
        {
            var transferResponse = new
            {
                Amount = transferOutput.Transaction.Amount,
                Description = transferOutput.Transaction.Description,
                TransactionDate = transferOutput.Transaction.TransactionDate,
                UpdatedBalance = transferOutput.UpdatedBalance,
            };
            ViewModel = new ObjectResult(transferResponse);
        }
    }
}