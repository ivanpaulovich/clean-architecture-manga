namespace Infrastructure.DataAccess.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Account",
            table => new
            {
                AccountId = table.Column<Guid>(nullable: false),
                ExternalUserId = table.Column<string>(nullable: false),
                Currency = table.Column<string>(nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Account", x => x.AccountId); });

        migrationBuilder.CreateTable(
            "Credit",
            table => new
            {
                CreditId = table.Column<Guid>(nullable: false),
                TransactionDate = table.Column<DateTime>(nullable: false),
                AccountId = table.Column<Guid>(nullable: false),
                Value = table.Column<decimal>(nullable: false),
                Currency = table.Column<string>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Credit", x => x.CreditId);
                table.ForeignKey(
                    "FK_Credit_Account_AccountId",
                    x => x.AccountId,
                    "Account",
                    "AccountId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "Debit",
            table => new
            {
                DebitId = table.Column<Guid>(nullable: false),
                TransactionDate = table.Column<DateTime>(nullable: false),
                AccountId = table.Column<Guid>(nullable: false),
                Value = table.Column<decimal>(nullable: false),
                Currency = table.Column<string>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Debit", x => x.DebitId);
                table.ForeignKey(
                    "FK_Debit_Account_AccountId",
                    x => x.AccountId,
                    "Account",
                    "AccountId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            "Account",
            new[] { "AccountId", "Currency", "ExternalUserId" },
            new object[]
            {
                    new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"), "USD", "197d0438-e04b-453d-b5de-eca05960c6ae"
            });

        migrationBuilder.InsertData(
            "Credit",
            new[] { "CreditId", "AccountId", "Currency", "TransactionDate", "Value" },
            new object[]
            {
                    new Guid("7bf066ba-379a-4e72-a59b-9755fda432ce"),
                    new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"), "USD",
                    new DateTime(2020, 8, 21, 6, 43, 4, 92, DateTimeKind.Utc).AddTicks(7795), 400m
            });

        migrationBuilder.InsertData(
            "Debit",
            new[] { "DebitId", "AccountId", "Currency", "TransactionDate", "Value" },
            new object[]
            {
                    new Guid("31ade963-bd69-4afb-9df7-611ae2cfa651"),
                    new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"), "USD",
                    new DateTime(2020, 8, 21, 6, 43, 4, 93, DateTimeKind.Utc).AddTicks(301), 400m
            });

        migrationBuilder.CreateIndex(
            "IX_Credit_AccountId",
            "Credit",
            "AccountId");

        migrationBuilder.CreateIndex(
            "IX_Debit_AccountId",
            "Debit",
            "AccountId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "Credit");

        migrationBuilder.DropTable(
            "Debit");

        migrationBuilder.DropTable(
            "Account");
    }
}
