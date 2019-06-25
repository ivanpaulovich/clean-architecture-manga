namespace Manga.WebApi.UseCases.Withdraw
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Withdraw;
    using Manga.Domain.ValueObjects;
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
            await _withdrawUseCase.Execute(new Input(request.AccountId, new PositiveAmount(request.Amount)));
            return _presenter.ViewModel;
        }
    }
}