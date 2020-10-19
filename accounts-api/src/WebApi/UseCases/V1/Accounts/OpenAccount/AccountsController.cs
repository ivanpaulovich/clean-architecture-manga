namespace WebApi.UseCases.V1.Accounts.OpenAccount
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.OpenAccount;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common;
    using Modules.Common.FeatureFlags;
    using ViewModels;

    /// <summary>
    ///     Customers
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.OpenAccount)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase, IOutputPort
    {
        private readonly Notification _notification;

        public AccountsController(Notification notification)
        {
            this._notification = notification;
        }

        private IActionResult? _viewModel;

        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._notification.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Account account) =>
            this._viewModel = this.Ok(new OpenAccountResponse(new AccountModel(account)));

        /// <summary>
        ///     Open an account.
        /// </summary>
        /// <response code="200">Customer already exists.</response>
        /// <response code="201">The registered customer was created successfully.</response>
        /// <response code="400">Bad request.</response>
        /// <param name="useCase">Use case.</param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <returns>The newly registered customer.</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OpenAccountResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OpenAccountResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Post))]
        public async Task<IActionResult> Post(
            [FromServices] IOpenAccountUseCase useCase,
            [FromForm] [Required] decimal amount,
            [FromForm] [Required] string currency)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(amount, currency)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
