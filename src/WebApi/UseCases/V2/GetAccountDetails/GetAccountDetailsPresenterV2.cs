namespace WebApi.UseCases.V2.GetAccountDetails
{
    using System.Data;
    using System;
    using Application.Boundaries.GetAccountDetails;
    using Microsoft.AspNetCore.Mvc;
    using OfficeOpenXml;
    using WebApi.ViewModels;

    public sealed class GetAccountDetailsPresenterV2 : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void Standard(GetAccountDetailsOutput getAccountDetailsOutput)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Amount", typeof(decimal));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("TransactionDate", typeof(DateTime));

            foreach (var item in getAccountDetailsOutput.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount.ToDecimal(),
                    item.Description,
                    item.TransactionDate);

                dataTable.Rows.Add(new object[] { item.Amount.ToDecimal(), item.Description, item.TransactionDate });
            }

            byte[] fileContents;

            using(ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(getAccountDetailsOutput.AccountId.ToString());
                ws.Cells["A1"].LoadFromDataTable(dataTable, true);
                ws.Row(1).Style.Font.Bold = true;
                ws.Column(3).Style.Numberformat.Format = "dd/MM/yyyy HH:mm";
                fileContents = pck.GetAsByteArray();
            }

            ViewModel = new FileContentResult(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}