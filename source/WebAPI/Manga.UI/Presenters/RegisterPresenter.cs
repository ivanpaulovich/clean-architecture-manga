namespace Manga.UI.Presenters
{
    using Manga.Application;
    using Manga.Application.UseCases.Register;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using System.Net.Http;

    public class RegisterPresenter : IOutputBoundary<Response>
    {
        public IActionResult ViewModel { get; private set; }

        public Response Response { get; private set; }

        public void Populate(Response response)
        {
            Response = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new ObjectResult(new
            {
                CustomerId = response.Customer.CustomerId,
                Personnummer = response.Customer.Personnummer,
                Name = response.Customer.Name
            });
        }
    }
}
