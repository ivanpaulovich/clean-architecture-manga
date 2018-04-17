namespace MyProject.WebApi.UseCases.GetAccountDetails
{
    using MyProject.Application;
    using MyProject.Application.UseCases.GetAccountDetails;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary<GetAccountDetailsInput> getAccountDetailsInput;
        private readonly Presenter getAccountDetailsPresenter;

        public AccountsController(
            IInputBoundary<GetAccountDetailsInput> getAccountDetailsInput,
            Presenter getAccountDetailsPresenter)
        {
            this.getAccountDetailsInput = getAccountDetailsInput;
            this.getAccountDetailsPresenter = getAccountDetailsPresenter;
        }

        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet("{accountId}", Name = "GetAccount")]
        public async Task<IActionResult> Get(Guid accountId)
        {
            var request = new GetAccountDetailsInput(accountId);

            await getAccountDetailsInput.Process(request);
            return getAccountDetailsPresenter.ViewModel;
        }
    }
}
