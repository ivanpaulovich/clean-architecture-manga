namespace Manga.WebApi.UseCases.CloseAccount
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public sealed class Presenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(Guid output)
        {
            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new OkResult();
        }
    }
}