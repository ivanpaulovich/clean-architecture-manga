// <copyright file="20191124223925_Users.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.EntityFrameworkDataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalUserId",
                table: "Customer");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ExternalUserId = table.Column<string>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => new { x.ExternalUserId, x.CustomerId });
                });

            migrationBuilder.UpdateData(
                table: "Credit",
                keyColumn: "Id",
                keyValue: new Guid("f5117315-e789-491a-b662-958c37237f9b"),
                column: "TransactionDate",
                value: new DateTime(2019, 11, 24, 22, 39, 24, 636, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Debit",
                keyColumn: "Id",
                keyValue: new Guid("3d6032df-7a3b-46e6-8706-be971e3d539f"),
                column: "TransactionDate",
                value: new DateTime(2019, 11, 24, 22, 39, 24, 636, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ExternalUserId", "CustomerId" },
                values: new object[] { "github/ivanpaulovich", new Guid("197d0438-e04b-453d-b5de-eca05960c6ae") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AddColumn<string>(
                name: "ExternalUserId",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Credit",
                keyColumn: "Id",
                keyValue: new Guid("f5117315-e789-491a-b662-958c37237f9b"),
                column: "TransactionDate",
                value: new DateTime(2019, 11, 16, 22, 15, 10, 176, DateTimeKind.Utc).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"),
                column: "ExternalUserId",
                value: "42");

            migrationBuilder.UpdateData(
                table: "Debit",
                keyColumn: "Id",
                keyValue: new Guid("3d6032df-7a3b-46e6-8706-be971e3d539f"),
                column: "TransactionDate",
                value: new DateTime(2019, 11, 16, 22, 15, 10, 176, DateTimeKind.Utc).AddTicks(5200));
        }
    }
}
