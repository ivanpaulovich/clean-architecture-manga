namespace WebApi.UseCases.V1.GetAccounts
{
    using Application.Boundaries.GetAccounts;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// </summary>
    public sealed class GetAccountsPresenter : IGetAccountsOutputPort
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        /// <summary>
        /// </summary>
        /// <param name="output"></param>
        public void Standard(GetAccountsOutput output)
        {
            var getAccountDetailsResponse = new GetAccountsResponse(output.Accounts);
            this.ViewModel = new OkObjectResult(getAccountDetailsResponse);
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
