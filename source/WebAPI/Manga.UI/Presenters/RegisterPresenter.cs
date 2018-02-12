namespace Manga.UI.Presenters
{
    using Manga.Application;
    using Manga.Application.UseCases.Register;
    using Manga.UI.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using System.Net.Http;

    public class RegisterPresenter : IOutputBoundary<RegisterResponse>
    {
        public IActionResult ViewModel { get; private set; }

        public RegisterResponse Response { get; private set; }

        public void Populate(RegisterResponse response)
        {
            Response = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new ObjectResult(new RegisterModel(
                response.Customer.CustomerId,
                response.Customer.Personnummer,
                response.Customer.Name
            ));
        }
    }
}
