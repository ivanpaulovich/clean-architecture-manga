namespace Infrastructure.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "User",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    ExternalUserId = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_User", x => x.UserId); });

            migrationBuilder.CreateTable(
                "Customer",
                table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    SSN = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        "FK_Customer_User_UserId",
                        x => x.UserId,
                        "User",
                        "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Account",
                table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    Currency = table.Column<string>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        "FK_Account_Customer_CustomerId",
                        x => x.CustomerId,
                        "Customer",
                        "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                "User",
                new[] {"UserId", "ExternalUserId"},
                new object[] {new Guid("e278ee65-6c41-42d6-9a73-838199a44d62"), "GitHub/7133698"});

            migrationBuilder.InsertData(
                "Customer",
                new[] {"CustomerId", "FirstName", "LastName", "SSN", "UserId"},
                new object[]
                {
                    new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"), "Ivan Paulovich", "Ivan Paulovich",
                    "8608179999", new Guid("e278ee65-6c41-42d6-9a73-838199a44d62")
                });

            migrationBuilder.InsertData(
                "Account",
                new[] {"AccountId", "Currency", "CustomerId"},
                new object[]
                {
                    new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"), "USD",
                    new Guid("197d0438-e04b-453d-b5de-eca05960c6ae")
                });

            migrationBuilder.InsertData(
                "Credit",
                new[] {"CreditId", "AccountId", "Currency", "TransactionDate", "Value"},
                new object[]
                {
                    new Guid("7bf066ba-379a-4e72-a59b-9755fda432ce"),
                    new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"), "USD",
                    new DateTime(2020, 7, 24, 11, 39, 34, 140, DateTimeKind.Utc).AddTicks(3504), 400m
                });

            migrationBuilder.InsertData(
                "Debit",
                new[] {"DebitId", "AccountId", "Currency", "TransactionDate", "Value"},
                new object[]
                {
                    new Guid("31ade963-bd69-4afb-9df7-611ae2cfa651"),
                    new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"), "USD",
                    new DateTime(2020, 7, 24, 11, 39, 34, 140, DateTimeKind.Utc).AddTicks(5105), 400m
                });

            migrationBuilder.CreateIndex(
                "IX_Account_CustomerId",
                "Account",
                "CustomerId");

            migrationBuilder.CreateIndex(
                "IX_Credit_AccountId",
                "Credit",
                "AccountId");

            migrationBuilder.CreateIndex(
                "IX_Customer_UserId",
                "Customer",
                "UserId");

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

            migrationBuilder.DropTable(
                "Customer");

            migrationBuilder.DropTable(
                "User");
        }
    }
}
