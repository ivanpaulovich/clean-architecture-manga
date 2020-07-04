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
        /// ViewModel result.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult? ViewModel { get; private set; }

        /// <summary>
        ///     The Account does not exist.
        /// </summary>
        /// <param name="message">Reason.</param>
        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        /// <summary>
        ///     Account details and its transactions.
        /// </summary>
        /// <param name="output">Transaction details.</param>
        public void Standard(GetAccountOutput output)
        {
            var getAccountResponse = new GetAccountResponse(output.Account);
            this.ViewModel = new OkObjectResult(getAccountResponse);
        }

        /// <summary>
        ///     An error happened.
        /// </summary>
        /// <param name="message">Reason.</param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
