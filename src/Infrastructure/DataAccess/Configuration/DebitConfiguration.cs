// <copyright file="DebitConfiguration.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Configuration
{
    using System;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Debit = Entities.Debit;

    /// <summary>
    ///     Debit Configuration.
    /// </summary>
    public sealed class DebitConfiguration : IEntityTypeConfiguration<Debit>
    {
        /// <summary>
        ///     Configure Debit.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<Debit> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Debit");

            builder.Property(debit => debit.Amount)
                .HasConversion(
                    value => value.ToMoney().ToDecimal(),
                    value => new PositiveMoney(value, "USD"))
                .IsRequired();

            builder.Property(debit => debit.Id)
                .HasConversion(
                    value => value.ToGuid(),
                    value => new DebitId(value))
                .IsRequired();

            builder.Property(debit => debit.AccountId)
                .HasConversion(
                    value => value.ToGuid(),
                    value => new AccountId(value))
                .IsRequired();

            builder.Property(credit => credit.TransactionDate)
                .IsRequired();
        }
    }
}
