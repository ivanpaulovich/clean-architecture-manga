namespace Manga.WebApi.UseCases.Transfer
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Transfer;
    using Manga.Domain.ValueObjects;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public sealed class AccountsController : Controller
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
        /// Transfer from an account to another
        /// </summary>
        [HttpPatch("Transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
        {
            await _withdrawUseCase.Execute(
                new Input(
                    request.OriginAccountId,
                    request.DestinationAccountId,
                    new PositiveAmount(request.Amount)
                ));
            return _presenter.ViewModel;
        }
    }
}