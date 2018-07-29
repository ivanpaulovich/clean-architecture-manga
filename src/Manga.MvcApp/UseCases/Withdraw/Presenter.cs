namespace Manga.MvcApp.UseCases.Withdraw
{
    using Manga.Application.UseCases.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    public sealed class Presenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(WithdrawOutput response, Controller controller)
        {
            ViewModel = controller.View();
        }
    }
}
