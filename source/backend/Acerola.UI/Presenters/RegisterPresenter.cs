namespace Acerola.UI.Presenters
{
    using Acerola.Application;
    using Acerola.Application.UseCases.Register;
    using Microsoft.AspNetCore.Mvc;

    public class RegisterPresenter : IOutputBoundary<Response>
    {
        public IActionResult ViewModel { get; private set; }

        public Response Response { get; private set; }

        public void Populate(Response response)
        {
            Response = response;

            if (response == null)
                ViewModel = new NotFoundResult();

            ViewModel = new ObjectResult(new
            {
                CustomerId = response.Customer.CustomerId,
                Personnummer = response.Customer.Personnummer,
                Name = response.Customer.Name
            });
        }
    }
}
