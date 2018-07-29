namespace Manga.MvcApp.UseCases.Withdraw
{
    using Manga.Application.UseCases.Withdraw;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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

        public IActionResult Withdraw()
        {
            return View();
        }

        /// <summary>
        /// Register a new Customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Withdraw(WithdrawRequest request)
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
