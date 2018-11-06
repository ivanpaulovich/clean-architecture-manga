namespace Manga.MvcApp.UseCases.Deposit
{
    using Manga.Application.UseCases.Deposit;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("[controller]")]
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

        [HttpGet("Deposit/{accountId}")]
        public IActionResult Deposit(Guid accountId)
        {
            ViewBag.AccountId = accountId;

            return View();
        }

        /// <summary>
        /// Deposit to an Account
        /// </summary>
        [HttpPost("Deposit/{accountId}")]
        public async Task<IActionResult> Deposit([FromRoute]Guid accountId, DepositRequest request)
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
