namespace Acerola.UI.Api.Presenters
{
    using Acerola.Application;
    using Acerola.Application.UseCases.Deposit;
    using Microsoft.AspNetCore.Mvc;

    public class DepositPresenter : IOutputBoundary<Response>
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
