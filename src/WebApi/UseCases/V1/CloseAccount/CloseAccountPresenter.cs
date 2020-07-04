namespace WebApi.UseCases.V1.CloseAccount
{
    using Application.Boundaries.CloseAccount;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Generates the Close Account presentations.
    /// </summary>
    public sealed class CloseAccountPresenter : ICloseAccountOutputPort
    {
        /// <summary>
        /// ViewModel result.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult? ViewModel { get; private set; }

        /// <summary>
        /// Produces a NotFound result.
        /// </summary>
        /// <param name="message">Message.</param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        /// Produces the Standard result.
        /// </summary>
        /// <param name="output">Output.</param>
        public void Standard(CloseAccountOutput output) =>
            this.ViewModel = new OkObjectResult(output.Account.Id);

        /// <summary>
        /// Produces a friendly Error result.
        /// </summary>
        /// <param name="message">Message.</param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
