namespace Manga.WebApi.UseCases.Withdraw
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IUseCase _withdrawUseCase;
        private readonly Presenter _presenter;

        public AccountsController(
            IUseCase withdrawUseCase,
            Presenter presenter)
        {
            _withdrawUseCase = withdrawUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Withdraw from an account
        /// </summary>
        [HttpPatch("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
        {
            await _withdrawUseCase.Execute(request.AccountId, request.Amount);
            return _presenter.ViewModel;
        }
    }
}