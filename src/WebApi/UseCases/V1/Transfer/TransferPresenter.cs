namespace WebApi.UseCases.V1.Transfer
{
    using Application.Boundaries.Transfer;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// </summary>
    public sealed class TransferPresenter : ITransferOutputPort
    {
        /// <summary>
        /// ViewModel result.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult? ViewModel { get; private set; }

        /// <summary>
        /// Account does not exist.
        /// </summary>
        /// <param name="message">Message.</param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        /// Standard output.
        /// </summary>
        /// <param name="output">Output.</param>
        public void Standard(TransferOutput output)
        {
            this.ViewModel = new NoContentResult();
        }

        /// <summary>
        /// An error happened.
        /// </summary>
        /// <param name="message">Message.</param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
