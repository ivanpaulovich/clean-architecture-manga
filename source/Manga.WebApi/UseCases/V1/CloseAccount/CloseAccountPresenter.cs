namespace Manga.WebApi.UseCases.V1.CloseAccount
{
    using Manga.Application.Boundaries.CloseAccount;
    using Microsoft.AspNetCore.Mvc;

    public sealed class CloseAccountPresenter : IOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void Handle(Output output)
        {
            ViewModel = new OkResult();
        }
    }
}