namespace Manga.WebApi.UseCases.Withdraw
{
    using Manga.Application.UseCases.Withdraw;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IWithdrawUseCase _withdrawUseCase;
        private readonly Presenter _presenter;

        public AccountsController(
            IWithdrawUseCase withdrawUseCase,
            Presenter presenter)
        {
            _withdrawUseCase = withdrawUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Withdraw from an account
        /// </summary>
        [HttpPatch("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody]WithdrawRequest request)
        {
            WithdrawOutput output = await _withdrawUseCase.Execute(request.AccountId, request.Amount);
            _presenter.Populate(output);
            return _presenter.ViewModel;
        }
    }
}
