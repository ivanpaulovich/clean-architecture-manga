namespace WebApi.UseCases.V1.Accounts.GetAccounts;

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.UseCases.GetAccounts;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using Modules.Common;
using Modules.Common.FeatureFlags;

/// <summary>
///     Accounts
///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
///         Controller Design Pattern
///     </see>
///     .
/// </summary>
[ApiVersion("1.0")]
[FeatureGate(CustomFeature.GetAccounts)]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public sealed class AccountsController : ControllerBase, IOutputPort
{
    private readonly IGetAccountsUseCase _useCase;

    private IActionResult? _viewModel;

    public AccountsController(IGetAccountsUseCase useCase) => this._useCase = useCase;

    void IOutputPort.Ok(IList<Account> accounts) => this._viewModel = this.Ok(new GetAccountsResponse(accounts));

    /// <summary>
    ///     Get Accounts.
    /// </summary>
    /// <response code="200">The List of Accounts.</response>
    /// <response code="404">Not Found.</response>
    /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAccountsResponse))]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> Get()
    {
        this._useCase.SetOutputPort(this);

        await this._useCase.Execute()
            .ConfigureAwait(false);

        return this._viewModel!;
    }
}
