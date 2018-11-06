namespace Manga.MvcApp.UseCases.GetAccount
{
    using Manga.Application.UseCases;
    using Manga.Application.UseCases.GetAccountDetails;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("[controller]")]
    public sealed class AccountsController : Controller
    {
        private readonly IGetAccountDetailsUseCase _getAccountDetailsUseCase;
        private readonly Presenter _presenter;

        public AccountsController(
            IGetAccountDetailsUseCase getAccountDetailsUseCase,
            Presenter presenter)
        {
            _getAccountDetailsUseCase = getAccountDetailsUseCase;
            _presenter = presenter;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            AccountOutput output = await _getAccountDetailsUseCase.Execute(accountId);
            _presenter.Populate(output, this);
            return _presenter.ViewModel;
        }
    }
}
