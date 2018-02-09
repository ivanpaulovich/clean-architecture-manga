namespace Acerola.UI.UseCases.Accounts.Close
{
    using Acerola.Application.Accounts.Close;
    using Microsoft.AspNetCore.Mvc;

    public class Presenter : IOutputBoundary
    {
        private IActionResult result;

        public Result Build()
        {
            return new Result();
        }
        
        public void Handle(Response response)
        {
            if (response != null)
                result = new OkResult();
        }
    }
}
