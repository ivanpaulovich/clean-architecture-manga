namespace Manga.UI.Presenters
{
    using Manga.Application;
    using Manga.Application.UseCases.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    public class WithdrawPresenter : IOutputBoundary<WithdrawResponse>
    {
        public IActionResult ViewModel { get; private set; }

        public WithdrawResponse Response { get; private set; }

        public void Populate(WithdrawResponse response)
        {
            Response = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new ObjectResult(new
            {
                Amount = response.Transaction.Amount,
                Description = response.Transaction.Description,
                TransactionDate = response.Transaction.TransactionDate,
                UpdateBalance = response.UpdatedBalance,
            });
        }
    }
}
