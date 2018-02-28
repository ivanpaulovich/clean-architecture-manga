namespace Manga.UI.Controllers
{
    using Manga.Application;
    using Manga.Application.UseCases.CloseAccount;
    using Manga.Application.UseCases.Deposit;
    using Manga.Application.UseCases.GetAccountDetails;
    using Manga.Application.UseCases.Withdraw;
    using Manga.UI.Presenters;
    using Manga.UI.Requests;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IInputBoundary<CloseInput> closeAccountInput;
        private readonly IInputBoundary<DepositInput> depositInput;
        private readonly IInputBoundary<WithdrawInput> withdrawInput;
        private readonly IInputBoundary<GetAccountDetailsInput> getAccountDetailsInput;

        private readonly ClosePresenter closePresenter;
        private readonly DepositPresenter depositPresenter;
        private readonly WithdrawPresenter withdrawPresenter;
        private readonly AccountDetailsPresenter getAccountDetailsPresenter;

        public AccountsController(
            IInputBoundary<CloseInput> closeAccountnput,
            IInputBoundary<DepositInput> depositnput,
            IInputBoundary<WithdrawInput> withdrawInput,
            IInputBoundary<GetAccountDetailsInput> getAccountDetailsInput,
            ClosePresenter closePresenter,
            DepositPresenter depositPresenter,
            WithdrawPresenter withdrawPresenter,
            AccountDetailsPresenter getAccountDetailsPresenter)
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
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> Close(Guid accountId)
        {
            var request = new CloseInput(accountId);

            await closeAccountInput.Handle(request);
            return closePresenter.ViewModel;
        }

        /// <summary>
        /// Deposit to an account
        /// </summary>
        [HttpPatch("Deposit")]
        public async Task<IActionResult> Deposit([FromBody]DepositRequest message)
        {
            var request = new DepositInput(message.AccountId, message.Amount);

            await depositInput.Handle(request);
            return depositPresenter.ViewModel;
        }

        /// <summary>
        /// Withdraw from an account
        /// </summary>
        [HttpPatch("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody]WithdrawRequest message)
        {
            var request = new WithdrawInput(message.AccountId, message.Amount);

            await withdrawInput.Handle(request);
            return withdrawPresenter.ViewModel;
        }


        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet("{accountId}", Name = "GetAccount")]
        public async Task<IActionResult> Get(Guid accountId)
        {
            var request = new GetAccountDetailsInput(accountId);

            await getAccountDetailsInput.Handle(request);
            return getAccountDetailsPresenter.ViewModel;
        }
    }
}
