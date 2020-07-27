// <copyright file="SeedData.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess
{
    using System;
    using Common;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// </summary>
    public static class SeedData
    {
        public static readonly ExternalUserId DefaultExternalUserId =
            new ExternalUserId("GitHub/7133698");

        public static readonly UserId DefaultUserId =
            new UserId(new Guid("E278EE65-6C41-42D6-9A73-838199A44D62"));

        public static readonly CustomerId DefaultCustomerId =
            new CustomerId(new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"));

        public static readonly AccountId DefaultAccountId =
            new AccountId(new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"));

        public static readonly AccountId SecondAccountId =
            new AccountId(new Guid("E82D2EA6-E9D3-444D-A22F-9D65F2F2C65E"));

        public static readonly CustomerId SecondCustomerId =
            new CustomerId(new Guid("C70E69BF-EDC7-48E3-BF33-B424F7464C5F"));

        public static readonly ExternalUserId SecondExternalUserId =
            new ExternalUserId("GitHub/7133699");

        public static readonly UserId SecondUserId =
            new UserId(new Guid("E7EC632A-FA91-453C-AC34-C4EDD8F637C3"));

        public static readonly CreditId DefaultCreditId =
            new CreditId(new Guid("7BF066BA-379A-4E72-A59B-9755FDA432CE"));

        public static readonly DebitId DefaultDebitId =
            new DebitId(new Guid("31ADE963-BD69-4AFB-9DF7-611AE2CFA651"));

        public static void Seed(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Entity<User>()
                .HasData(
                    new {UserId = DefaultUserId, ExternalUserId = DefaultExternalUserId});

            builder.Entity<Customer>()
                .HasData(
                    new
                    {
                        CustomerId = DefaultCustomerId,
                        FirstName = new Name(Messages.UserName),
                        LastName = new Name(Messages.UserName),
                        SSN = new SSN(Messages.UserSSN),
                        UserId = DefaultUserId
                    });

            builder.Entity<Account>()
                .HasData(
                    new {AccountId = DefaultAccountId, CustomerId = DefaultCustomerId, Currency = Currency.Dollar});

            builder.Entity<Credit>()
                .HasData(
                    new
                    {
                        CreditId = DefaultCreditId,
                        AccountId = DefaultAccountId,
                        TransactionDate = DateTime.UtcNow,
                        Value = 400m,
                        Currency = Currency.Dollar.Code
                    });

            builder.Entity<Debit>()
                .HasData(
                    new
                    {
                        DebitId = DefaultDebitId,
                        AccountId = DefaultAccountId,
                        TransactionDate = DateTime.UtcNow,
                        Value = 400m,
                        Currency = Currency.Dollar.Code
                    });
        }
    }
}
