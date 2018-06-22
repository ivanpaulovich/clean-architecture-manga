namespace Manga.WebApi.UseCases.Deposit
{
    using Manga.Application.UseCases.Deposit;
    using Microsoft.AspNetCore.Mvc;

    public class Presenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(DepositOutput output)
        {
            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new ObjectResult(new CurrentAccountBalanceModel(
                output.Transaction.Amount,
                output.Transaction.Description,
                output.Transaction.TransactionDate,
                output.UpdatedBalance
            ));
        }
    }
}
