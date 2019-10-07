namespace Manga.WebApi.UseCases.V1.Deposit
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Deposit;
    using Manga.Domain.ValueObjects;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        private readonly IUseCase _depositUseCase;
        private readonly DepositPresenter _presenter;

        public AccountsController(
            IUseCase depositUseCase,
            DepositPresenter presenter)
        {
            _depositUseCase = depositUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Deposit on an account
        /// </summary>
        /// <response code="200">The updated balance.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to deposit.</param>
        /// <returns>The updated balance.</returns>
        [HttpPatch("Deposit")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DepositResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Deposit([FromBody][Required] DepositRequest request)
        {
            var depositInput = new DepositInput(
                request.AccountId,
                new PositiveMoney(request.Amount)
            );

            await _depositUseCase.Execute(depositInput);
            return _presenter.ViewModel;
        }
    }
}
