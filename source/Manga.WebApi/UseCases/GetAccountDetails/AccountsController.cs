namespace Manga.WebApi.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.GetAccountDetails;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IUseCase _getAccountDetailsUseCase;
        private readonly Presenter _presenter;

        public AccountsController(
            IUseCase getAccountDetailsUseCase,
            Presenter presenter)
        {
            _getAccountDetailsUseCase = getAccountDetailsUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet("{accountId}", Name = "GetAccount")]
        public async Task<IActionResult> Get(Guid accountId)
        {
            await _getAccountDetailsUseCase.Execute(new Input(accountId));
            return _presenter.ViewModel;
        }
    }
}