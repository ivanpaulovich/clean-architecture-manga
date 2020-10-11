// <copyright file="AccountConfiguration.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Configuration
{
    using System;
    using Domain;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Account Configuration.
    /// </summary>
    public sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        /// <summary>
        ///     Configure Account.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Account");

            builder.Property(b => b.AccountId)
                .HasConversion(
                    v => v.Id,
                    v => new AccountId(v))
                .IsRequired();

            builder.Property(credit => credit.Currency)
                .HasConversion(
                    value => value.Code,
                    value => new Currency(value))
                .IsRequired();

            builder.Property(b => b.ExternalUserId)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasMany(x => x.CreditsCollection)
                .WithOne(b => b.Account!)
                .HasForeignKey(b => b.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.DebitsCollection)
                .WithOne(b => b.Account!)
                .HasForeignKey(b => b.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
