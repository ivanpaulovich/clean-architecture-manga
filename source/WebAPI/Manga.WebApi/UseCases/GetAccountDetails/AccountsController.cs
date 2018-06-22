namespace Manga.WebApi.UseCases.GetAccountDetails
{
    using Manga.Application.UseCases;
    using Manga.Application.UseCases.GetAccountDetails;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountsController : Controller
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

        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet("{accountId}", Name = "GetAccount")]
        public async Task<IActionResult> Get(Guid accountId)
        {
            AccountOutput output = await _getAccountDetailsUseCase.Execute(accountId);
            _presenter.Populate(output);
            return _presenter.ViewModel;
        }
    }
}
