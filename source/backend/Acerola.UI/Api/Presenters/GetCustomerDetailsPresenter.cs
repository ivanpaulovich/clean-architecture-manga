namespace Acerola.UI.Api.Presenters
{
    using Acerola.Application;
    using Acerola.Application.UseCases.GetCustomerDetails;
    using Microsoft.AspNetCore.Mvc;

    public class GetCustomerDetailsPresenter : IOutputBoundary<Customer>
    {
        public IActionResult ViewModel { get; private set; }
               
        public void Populate(Customer response)
        {
            if (response == null)
                ViewModel = new ContentResult();

            ViewModel = new OkResult();
        }
    }
}
