namespace WebApi.UseCases.V1.CloseAccount
{
    using Application.Boundaries.CloseAccount;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// </summary>
    public sealed class CloseAccountPresenter : ICloseAccountOutputPort
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        /// </summary>
        /// <param name="output"></param>
        public void Standard(CloseAccountOutput output) =>
            this.ViewModel = new OkObjectResult(output.Account.Id);

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
