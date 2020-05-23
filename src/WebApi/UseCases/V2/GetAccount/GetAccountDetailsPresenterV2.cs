namespace WebApi.UseCases.V2.GetAccount
{
    using System;
    using System.Data;
    using Application.Boundaries.GetAccount;
    using Domain.Accounts;
    using Microsoft.AspNetCore.Mvc;
    using OfficeOpenXml;

    public sealed class GetAccountDetailsPresenterV2 : IGetAccountOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message) => this.ViewModel = new NotFoundObjectResult(message);

        public void Standard(GetAccountOutput getAccountOutput)
        {
            using var dataTable = new DataTable();
            dataTable.Columns.Add("AccountId", typeof(Guid));
            dataTable.Columns.Add("Amount", typeof(decimal));

            var account = (Account)getAccountOutput.Account;

            dataTable.Rows.Add(account.Id.ToGuid(), account.GetCurrentBalance().ToDecimal());

            byte[] fileContents;

            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(account.Id.ToString());
                ws.Cells["A1"].LoadFromDataTable(dataTable, true);
                ws.Row(1).Style.Font.Bold = true;
                ws.Column(3).Style.Numberformat.Format = "dd/MM/yyyy HH:mm";
                fileContents = pck.GetAsByteArray();
            }

            this.ViewModel = new FileContentResult(fileContents,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(message);
    }
}
