namespace MyProject.WebApi.UseCases.Withdraw
{
    using MyProject.Application;
    using MyProject.Application.UseCases.Withdraw;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary<WithdrawInput> withdrawInput;
        private readonly Presenter withdrawPresenter;
        
        public AccountsController(
            IInputBoundary<WithdrawInput> withdrawInput,
            Presenter withdrawPresenter)
        {
            this.withdrawInput = withdrawInput;
            this.withdrawPresenter = withdrawPresenter;
        }

        /// <summary>
        /// Withdraw from an account
        /// </summary>
        [HttpPatch("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody]WithdrawRequest message)
        {
            var request = new WithdrawInput(message.AccountId, message.Amount);

            await withdrawInput.Process(request);
            return withdrawPresenter.ViewModel;
        }
    }
}
