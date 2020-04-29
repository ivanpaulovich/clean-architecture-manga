namespace WebApi.UseCases.V1.GetAccount
{
    using Application.Boundaries.GetAccount;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    /// <summary>
    /// </summary>
    public sealed class GetAccountPresenter : IGetAccountOutputPort
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
        /// <param name="getAccountOutput"></param>
        public void Standard(GetAccountOutput getAccountOutput)
        {
            var getAccountModel = new AccountModel(getAccountOutput.Account);
            var getAccountResponse = new GetAccountResponse(getAccountModel);
            this.ViewModel = new OkObjectResult(getAccountResponse);
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
