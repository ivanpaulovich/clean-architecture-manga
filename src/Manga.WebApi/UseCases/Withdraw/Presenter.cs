namespace Manga.WebApi.UseCases.Withdraw
{
    using Manga.Application.UseCases.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    public class Presenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(WithdrawOutput output)
        {
            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new ObjectResult(new
            {
                Amount = output.Transaction.Amount,
                Description = output.Transaction.Description,
                TransactionDate = output.Transaction.TransactionDate,
                UpdatedBalance = output.UpdatedBalance,
            });
        }
    }
}
