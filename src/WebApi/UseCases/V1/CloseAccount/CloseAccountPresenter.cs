namespace WebApi.UseCases.V1.CloseAccount
{
    using Application.Boundaries.CloseAccount;
    using Microsoft.AspNetCore.Mvc;

    public sealed class CloseAccountPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void Standard(CloseAccountOutput closeAccountOutput)
        {
            ViewModel = new OkObjectResult(closeAccountOutput.AccountId);
        }
    }
}
