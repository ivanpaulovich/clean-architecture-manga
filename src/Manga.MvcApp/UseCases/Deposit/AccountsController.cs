namespace Manga.MvcApp.UseCases.Deposit
{
    using Manga.Application.UseCases.Deposit;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public sealed class AccountsController : Controller
    {
        private readonly IDepositUseCase _depositUseCase;
        private readonly Presenter _presenter;

        public AccountsController(
            IDepositUseCase depositUseCase,
            Presenter presenter)
        {
            _depositUseCase = depositUseCase;
            _presenter = presenter;
        }

        public IActionResult Deposit()
        {
            return View();
        }

        /// <summary>
        /// Register a new Customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Deposit(DepositRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            DepositOutput output = await _depositUseCase.Execute(
                request.AccountId,
                request.Amount);

            _presenter.Populate(output, this);

            return _presenter.ViewModel;
        }
    }
}
