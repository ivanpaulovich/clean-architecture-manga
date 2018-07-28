namespace Manga.MvcApp.UseCases.Deposit
{
    using Manga.Application.UseCases.Deposit;
    using Microsoft.AspNetCore.Mvc;

    public sealed class Presenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(DepositOutput response, Controller controller)
        {
            ViewModel = controller.View();
        }
    }
}
