namespace WebApi.UseCases.V1.GetAccount
{
    using Application.Boundaries.GetAccount;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Renders an Account with its Transactions
    /// </summary>
    public sealed class GetAccountPresenter : IGetAccountOutputPort
    {
        /// <summary>
        ///     ViewModel
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        /// <summary>
        ///     The Account does not exist.
        /// </summary>
        /// <param name="message">Reason.</param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        ///     Account details and its transactions.
        /// </summary>
        /// <param name="getAccountOutput">Transaction details.</param>
        public void Standard(GetAccountOutput getAccountOutput)
        {
            var getAccountResponse = new GetAccountResponse(getAccountOutput.Account);
            this.ViewModel = new OkObjectResult(getAccountResponse);
        }

        /// <summary>
        ///     An error happened.
        /// </summary>
        /// <param name="message">Reason.</param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
