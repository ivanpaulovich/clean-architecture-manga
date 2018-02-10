namespace Acerola.UI.Api.Presenters
{
    using Acerola.Application;
    using Acerola.Application.UseCases.ListAllCustomers;
    using Microsoft.AspNetCore.Mvc;

    public class ListAllCustomersPresenter : IOutputBoundary<Response>
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
