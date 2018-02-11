namespace Acerola.UI.Presenters
{
    using Acerola.Application;
    using Acerola.Application.UseCases.CloseAccount;
    using Microsoft.AspNetCore.Mvc;

    public class ClosePresenter : IOutputBoundary<Response>
    {
        public IActionResult ViewModel { get; private set; }

        public Response Response { get; private set; }

        public void Populate(Response response)
        {
            Response = response;

            if (response == null)
                ViewModel = new OkResult();

            ViewModel = new OkResult();
        }
    }
}