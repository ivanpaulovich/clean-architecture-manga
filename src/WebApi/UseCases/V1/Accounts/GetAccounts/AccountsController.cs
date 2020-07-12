namespace WebApi.UseCases.V1.Accounts.GetAccounts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.UseCases.GetAccounts;
    using Domain.Accounts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Modules.Common;

    /// <summary>
    ///     Accounts
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(IList<Account> accounts) => this._viewModel = this.Ok(new GetAccountsResponse(accounts));

        /// <summary>
        ///     Get Accounts.
        /// </summary>
        /// <response code="200">The List of Accounts.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="useCase">Use case.</param>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountsResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task<IActionResult> Get([FromServices] IGetAccountsUseCase useCase)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute()
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
