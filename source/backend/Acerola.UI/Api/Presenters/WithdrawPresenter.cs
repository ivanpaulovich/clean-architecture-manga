namespace Acerola.UI.Api.Presenters
{
    using Acerola.Application;
    using Acerola.Application.UseCases.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    public class WithdrawPresenter : IOutputBoundary<Response>
    {
        public Microsoft.AspNetCore.Mvc.IActionResult ViewModel { get; private set; }
               
        public void Populate(Response response)
        {
            if (response == null)
                ViewModel = new ContentResult();

            ViewModel = new OkResult();
        }
    }
}
