namespace WebApi.UseCases.V2.Accounts.GetAccount;

using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Threading.Tasks;
using Application.Services;
using Application.UseCases.GetAccount;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using Modules.Common.FeatureFlags;
using OfficeOpenXml;

/// <summary>
///     Accounts
///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
///         Controller Design Pattern
///     </see>
///     .
/// </summary>
[FeatureGate(CustomFeature.GetAccountV2)]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public sealed class AccountsController : ControllerBase, IOutputPort
{
    private readonly Notification _notification;

    private IActionResult? _viewModel;

    public AccountsController(Notification notification) => this._notification = notification;

    void IOutputPort.Invalid()
    {
        ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._notification.ModelState);
        this._viewModel = this.BadRequest(problemDetails);
    }

    void IOutputPort.NotFound() => this._viewModel = this.NotFound();

    void IOutputPort.Ok(Account account)
    {
        using DataTable dataTable = new DataTable();
        dataTable.Columns.Add("AccountId", typeof(Guid));
        dataTable.Columns.Add("Amount", typeof(decimal));

        dataTable.Rows.Add(account.AccountId.Id, account.GetCurrentBalance().Amount);

        byte[] fileContents;

        using (ExcelPackage pck = new ExcelPackage())
        {
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add(account.AccountId.ToString());
            ws.Cells["A1"].LoadFromDataTable(dataTable, true);
            ws.Row(1).Style.Font.Bold = true;
            ws.Column(3).Style.Numberformat.Format = "dd/MM/yyyy HH:mm";
            fileContents = pck.GetAsByteArray();
        }

        this._viewModel = new FileContentResult(fileContents,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }

    /// <summary>
    ///     Get an account details.
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="request">A <see cref="GetAccountDetailsRequestV2"></see>.</param>
    /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
    [Authorize]
    [HttpGet("{AccountId:guid}", Name = "GetAccountV2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(
        [FromServices] IGetAccountUseCase useCase,
        [FromRoute][Required] GetAccountDetailsRequestV2 request)
    {
        useCase.SetOutputPort(this);

        await useCase.Execute(request.AccountId)
            .ConfigureAwait(false);

        return this._viewModel!;
    }
}
