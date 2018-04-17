namespace MyProject.WebApi.UseCases.CloseAccount
{
    using MyProject.Application;
    using MyProject.Application.UseCases.CloseAccount;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary<CloseInput> closeAccountInput;
        private readonly Presenter closePresenter;
        public AccountsController(
            IInputBoundary<CloseInput> closeAccountnput,
            Presenter closePresenter)
        {
            this.closeAccountInput = closeAccountnput;
            this.closePresenter = closePresenter;
        }

        /// <summary>
        /// Close the account
        /// </summary>
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> Close(Guid accountId)
        {
            var request = new CloseInput(accountId);

            await closeAccountInput.Process(request);
            return closePresenter.ViewModel;
        }
    }
}
