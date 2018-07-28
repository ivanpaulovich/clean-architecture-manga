namespace Manga.MvcApp.UseCases.Register
{
    using Manga.Application.UseCases.Register;
    using Microsoft.AspNetCore.Mvc;

    public sealed class Presenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(RegisterOutput response)
        {
            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new RedirectToActionResult("GetCustomer", "Customers", new { customerId = response.Customer.CustomerId });
        }
    }
}
