// <copyright file="CreditConfiguration.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Configuration
{
    using System;
    using Domain.Accounts.Credits;
    using Domain.Accounts.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Credit = Entities.Credit;

    /// <summary>
    ///     Credit Configuration.
    /// </summary>
    public sealed class CreditConfiguration : IEntityTypeConfiguration<Credit>
    {
        /// <summary>
        ///     Configure Credit.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Credit");

            builder.Property(credit => credit.Amount)
                .HasConversion(
                    value => value.ToMoney().ToDecimal(),
                    value => new PositiveMoney(value, "USD"))
                .IsRequired();

            builder.Property(credit => credit.Id)
                .HasConversion(
                    value => value.ToGuid(),
                    value => new CreditId(value))
                .IsRequired();

            builder.Property(credit => credit.AccountId)
                .HasConversion(
                    value => value.ToGuid(),
                    value => new AccountId(value))
                .IsRequired();

            builder.Property(credit => credit.TransactionDate)
                .IsRequired();
        }
    }
}
