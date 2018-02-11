namespace Acerola.UI.Api.Presenters
{
    using Acerola.Application;
    using Acerola.Application.UseCases.ListAllAccounts;
    using Microsoft.AspNetCore.Mvc;

    public class ListAllAccountsPresenter : IOutputBoundary<Response>
    {
        public IActionResult ViewModel { get; private set; }
               
        public void Populate(Response response)
        {
            if (response == null)
                ViewModel = new ContentResult();

            ViewModel = new OkResult();
        }
    }
}
