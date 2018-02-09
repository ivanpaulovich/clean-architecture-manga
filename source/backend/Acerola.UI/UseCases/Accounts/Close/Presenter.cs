namespace Acerola.UI.UseCases.Accounts.Close
{
    using Acerola.Application.Accounts.Close;
    using Microsoft.AspNetCore.Mvc;

    public class Presenter : IOutputBoundary
    {
        public IActionResult ViewModel { get; private set; }
               
        public void Populate(ResponseModel response)
        {
            if (response != null)
                ViewModel = new OkResult();
        }
    }
}
