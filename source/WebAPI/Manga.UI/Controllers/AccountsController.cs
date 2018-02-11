namespace Manga.UI.Controllers
{
    using Manga.Application;
    using Manga.UI.Presenters;
    using Manga.UI.Requests;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IInputBoundary<Application.UseCases.CloseAccount.Request> closeAccountInput;
        private readonly IInputBoundary<Application.UseCases.Deposit.Request> depositInput;
        private readonly IInputBoundary<Application.UseCases.Withdraw.Request> withdrawInput;
        private readonly IInputBoundary<Application.UseCases.GetAccountDetails.Request> getAccountDetailsInput;

        private readonly ClosePresenter closePresenter;
        private readonly DepositPresenter depositPresenter;
        private readonly WithdrawPresenter withdrawPresenter;
        private readonly GetAccountDetailsPresenter getAccountDetailsPresenter;

        public AccountsController(
            IInputBoundary<Application.UseCases.CloseAccount.Request> closeAccountnput,
            IInputBoundary<Application.UseCases.Deposit.Request> depositnput,
            IInputBoundary<Application.UseCases.Withdraw.Request> withdrawInput,
            IInputBoundary<Application.UseCases.GetAccountDetails.Request> getAccountDetailsInput,
            ClosePresenter closePresenter,
            DepositPresenter depositPresenter,
            WithdrawPresenter withdrawPresenter,
            GetAccountDetailsPresenter getAccountDetailsPresenter)
        {
            this.closeAccountInput = closeAccountnput;
            this.depositInput = depositnput;
            this.withdrawInput = withdrawInput;
            this.getAccountDetailsInput = getAccountDetailsInput;

            this.closePresenter = closePresenter;
            this.depositPresenter = depositPresenter;
            this.withdrawPresenter = withdrawPresenter;
            this.getAccountDetailsPresenter = getAccountDetailsPresenter;
        }

        /// <summary>
        /// Close the account
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Close([FromBody]CloseRequest message)
        {
            var request = new Application.UseCases.CloseAccount.Request(
                message.AccountId);

            await closeAccountInput.Handle(request);
            return closePresenter.ViewModel;
        }

        /// <summary>
        /// Deposit to an account
        /// </summary>
        [HttpPatch("Deposit")]
        public async Task<IActionResult> Deposit([FromBody]DepositRequest message)
        {
            var request = new Application.UseCases.Deposit.Request(
                message.AccountId,
                message.Amount);

            await depositInput.Handle(request);
            return depositPresenter.ViewModel;
        }

        /// <summary>
        /// Withdraw from an account
        /// </summary>
        [HttpPatch("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody]WithdrawRequest message)
        {
            var request = new Application.UseCases.Withdraw.Request(
                message.AccountId,
                message.Amount);

            await withdrawInput.Handle(request);
            return withdrawPresenter.ViewModel;
        }


        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<IActionResult> Get(Guid id)
        {
            var request = new Application.UseCases.GetAccountDetails.Request(
                id);

            await getAccountDetailsInput.Handle(request);
            return getAccountDetailsPresenter.ViewModel;
        }
    }
}
