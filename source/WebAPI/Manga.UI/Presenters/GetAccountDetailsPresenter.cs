namespace Manga.UI.Presenters
{
    using Manga.Application;
    using Manga.Application.Responses;
    using Microsoft.AspNetCore.Mvc;

    public class GetAccountDetailsPresenter : IOutputBoundary<AccountResponse>
    {
        public IActionResult ViewModel { get; private set; }
        public AccountResponse Response { get; private set; }

        public void Populate(AccountResponse response)
        {
            Response = response;

            if (response == null)
                ViewModel = new OkResult();

            ViewModel = new OkResult();
        }
    }
}
