namespace Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Credit = Entities.Credit;
    using Debit = Entities.Debit;

    public static class SeedData
    {
        public static readonly CustomerId DefaultCustomerId =
            new CustomerId(new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"));

        public static readonly AccountId DefaultAccountId =
            new AccountId(new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"));

        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasData(
                new {Id = DefaultCustomerId, Name = new Name("Test User"), SSN = new SSN("19860817-9999")});

            builder.Entity<Account>().HasData(
                new {Id = DefaultAccountId, CustomerId = DefaultCustomerId});

            builder.Entity<Credit>().HasData(
                new
                {
                    Id = new CreditId(new Guid("f5117315-e789-491a-b662-958c37237f9b")),
                    AccountId = DefaultAccountId,
                    Amount = new PositiveMoney(400),
                    Description = "Credit",
                    TransactionDate = DateTime.UtcNow
                });

            builder.Entity<Debit>().HasData(
                new
                {
                    Id = new DebitId(new Guid("3d6032df-7a3b-46e6-8706-be971e3d539f")),
                    AccountId = DefaultAccountId,
                    Amount = new PositiveMoney(400),
                    Description = "Debit",
                    TransactionDate = DateTime.UtcNow
                });

            builder.Entity<User>().HasData(
                new {CustomerId = DefaultCustomerId, ExternalUserId = new ExternalUserId("github/ivanpaulovich")});
        }
    }
}
