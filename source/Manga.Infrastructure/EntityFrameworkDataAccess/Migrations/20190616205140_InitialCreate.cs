using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manga.Infrastructure.EntityFrameworkDataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns : table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                        CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credit",
                columns : table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                        AccountId = table.Column<Guid>(nullable: false),
                        Amount = table.Column<double>(nullable: true),
                        TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns : table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                        Name = table.Column<string>(nullable: true),
                        SSN = table.Column<string>(nullable: true)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Debit",
                columns : table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                        AccountId = table.Column<Guid>(nullable: false),
                        Amount = table.Column<double>(nullable: true),
                        TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Debit", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns : new [] { "Id", "Name", "SSN" },
                values : new object[] { new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"), "Manga.Domain.ValueObjects.Name", "Manga.Domain.ValueObjects.SSN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Debit");
        }
    }
}