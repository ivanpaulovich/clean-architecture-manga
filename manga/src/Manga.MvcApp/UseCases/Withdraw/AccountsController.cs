namespace Manga.MvcApp.UseCases.Withdraw
{
    using Manga.Application.UseCases.Withdraw;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("[controller]")]
    public sealed class AccountsController : Controller
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

        [HttpGet("Withdraw/{accountId}")]
        public IActionResult Withdraw(Guid accountId)
        {
            ViewBag.AccountId = accountId;

            return View();
        }

        /// <summary>
        /// Withdraw from an Account
        /// </summary>
        [HttpPost("Withdraw/{accountId}")]
        public async Task<IActionResult> Withdraw([FromRoute]Guid accountId, WithdrawRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            WithdrawOutput output = await _withdrawUseCase.Execute(
                request.AccountId,
                request.Amount);

            _presenter.Populate(output, this);

            return _presenter.ViewModel;
        }
    }
}
