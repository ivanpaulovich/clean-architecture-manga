namespace Manga.WebApi.UseCases.Deposit
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Deposit;
    using Manga.Domain.ValueObjects;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IUseCase _depositUseCase;
        private readonly Presenter _presenter;

        public AccountsController(
            IUseCase depositUseCase,
            Presenter presenter)
        {
            _depositUseCase = depositUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Deposit to an account
        /// </summary>
        [HttpPatch("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest message)
        {
            await _depositUseCase.Execute(new Input(message.AccountId, new PositiveAmount(message.Amount)));
            return _presenter.ViewModel;
        }
    }
}