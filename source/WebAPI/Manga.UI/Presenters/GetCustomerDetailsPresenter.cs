namespace Manga.UI.Presenters
{
    using Manga.Application;
    using Manga.Application.Responses;
    using Microsoft.AspNetCore.Mvc;

    public class GetCustomerDetailsPresenter : IOutputBoundary<CustomerResponse>
    {
        public IActionResult ViewModel { get; private set; }
        public CustomerResponse Response { get; private set; }

        public void Populate(CustomerResponse response)
        {
            Response = response;

            if (response == null)
                ViewModel = new NotFoundResult();

            ViewModel = new ObjectResult(new
            {
                CustomerId = response.CustomerId,
                Personnummer = response.Personnummer,
                Name = response.Name
            });
        }
    }
}
