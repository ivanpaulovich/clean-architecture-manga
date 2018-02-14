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
        private readonly IInputBoundary<CloseCommand> closeAccountInput;
        private readonly IInputBoundary<DepositCommand> depositInput;
        private readonly IInputBoundary<WithdrawCommand> withdrawInput;
        private readonly IInputBoundary<GetAccountDetailsCommand> getAccountDetailsInput;

        private readonly ClosePresenter closePresenter;
        private readonly DepositPresenter depositPresenter;
        private readonly WithdrawPresenter withdrawPresenter;
        private readonly AccountDetailsPresenter getAccountDetailsPresenter;

        public AccountsController(
            IInputBoundary<CloseCommand> closeAccountnput,
            IInputBoundary<DepositCommand> depositnput,
            IInputBoundary<WithdrawCommand> withdrawInput,
            IInputBoundary<GetAccountDetailsCommand> getAccountDetailsInput,
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
            var request = new CloseCommand(accountId);

            await closeAccountInput.Handle(request);
            return closePresenter.ViewModel;
        }

        /// <summary>
        /// Deposit to an account
        /// </summary>
        [HttpPatch("Deposit")]
        public async Task<IActionResult> Deposit([FromBody]DepositRequest message)
        {
            var request = new DepositCommand(message.AccountId, message.Amount);

            await depositInput.Handle(request);
            return depositPresenter.ViewModel;
        }

        /// <summary>
        /// Withdraw from an account
        /// </summary>
        [HttpPatch("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody]WithdrawRequest message)
        {
            var request = new WithdrawCommand(message.AccountId, message.Amount);

            await withdrawInput.Handle(request);
            return withdrawPresenter.ViewModel;
        }


        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet("{accountId}", Name = "GetAccount")]
        public async Task<IActionResult> Get(Guid accountId)
        {
            var request = new GetAccountDetailsCommand(accountId);

            await getAccountDetailsInput.Handle(request);
            return getAccountDetailsPresenter.ViewModel;
        }
    }
}
