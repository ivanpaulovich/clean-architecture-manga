namespace WebApi.UseCases.V1.CloseAccount
{
    using Application.Boundaries.CloseAccount;
    using Microsoft.AspNetCore.Mvc;

    public sealed class CloseAccountPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            this.ViewModel = new NotFoundObjectResult(message);
        }

        public void Standard(CloseAccountOutput closeAccountOutput)
        {
            this.ViewModel = new OkObjectResult(closeAccountOutput.AccountId);
        }

        public void WriteError(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }
    }
}
