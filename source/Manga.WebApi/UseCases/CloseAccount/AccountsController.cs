namespace Manga.WebApi.UseCases.CloseAccount
{
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.CloseAccount;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IUseCase _closeAccountUseCase;
        private readonly Presenter _presenter;

        public AccountsController(
            IUseCase closeAccountUseCase,
            Presenter presenter)
        {
            _closeAccountUseCase = closeAccountUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Close the account
        /// </summary>
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> Close(Guid accountId)
        {
            await _closeAccountUseCase.Execute(new Input(accountId));
            return _presenter.ViewModel;
        }
    }
}