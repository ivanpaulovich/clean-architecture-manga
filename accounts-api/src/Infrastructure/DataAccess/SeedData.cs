// <copyright file="SeedData.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess
{
    using System;
    using Domain;
    using Domain.Credits;
    using Domain.Debits;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// </summary>
    public static class SeedData
    {
        public static readonly string DefaultExternalUserId = "197d0438-e04b-453d-b5de-eca05960c6ae";

        public static readonly AccountId DefaultAccountId =
            new AccountId(new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"));

        public static readonly AccountId SecondAccountId =
            new AccountId(new Guid("E82D2EA6-E9D3-444D-A22F-9D65F2F2C65E"));

        public static readonly string SecondExternalUserId = "C70E69BF-EDC7-48E3-BF33-B424F7464C5F";

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

            builder.Entity<Account>()
                .HasData(
                    new
                    {
                        AccountId = DefaultAccountId,
                        ExternalUserId = DefaultExternalUserId,
                        Currency = Currency.Dollar
                    });

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
                        Value = 50m,
                        Currency = Currency.Dollar.Code
                    });
        }
    }
}
