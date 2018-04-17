namespace MyProject.WebApi.UseCases.Deposit
{
    using MyProject.Application;
    using MyProject.Application.UseCases.Deposit;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary<DepositInput> depositInput;
        private readonly Presenter depositPresenter;

        public AccountsController(
            IInputBoundary<DepositInput> depositnput,
            Presenter depositPresenter)
        {
            this.depositInput = depositnput;
            this.depositPresenter = depositPresenter;
        }

        /// <summary>
        /// Deposit to an account
        /// </summary>
        [HttpPatch("Deposit")]
        public async Task<IActionResult> Deposit([FromBody]DepositRequest message)
        {
            var request = new DepositInput(message.AccountId, message.Amount);

            await depositInput.Process(request);
            return depositPresenter.ViewModel;
        }
    }
}
