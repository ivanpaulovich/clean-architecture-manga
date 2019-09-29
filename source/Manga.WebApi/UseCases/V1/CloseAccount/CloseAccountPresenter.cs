namespace Manga.WebApi.UseCases.V1.CloseAccount
{
    using Manga.Application.Boundaries.CloseAccount;
    using Microsoft.AspNetCore.Mvc;

    public sealed class CloseAccountPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Standard(CloseAccountOutput closeAccountOutput)
        {
            ViewModel = new OkResult();
        }
    }
}