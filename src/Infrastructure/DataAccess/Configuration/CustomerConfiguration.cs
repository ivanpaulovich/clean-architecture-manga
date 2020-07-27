// <copyright file="CustomerConfiguration.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Configuration
{
    using System;
    using Common;
    using Domain.Customers.ValueObjects;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Customer Configuration.
    /// </summary>
    public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        ///     Configure Customer.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder
            <Customer> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Customer");

            builder.Property(b => b.SSN)
                .HasConversion(
                    v => v.Text,
                    v => new SSN(v))
                .IsRequired();

            builder.Property(b => b.FirstName)
                .HasConversion(
                    v => v.Text,
                    v => new Name(v))
                .IsRequired();

            builder.Property(b => b.LastName)
                .HasConversion(
                    v => v.Text,
                    v => new Name(v))
                .IsRequired();

            builder.Property(b => b.UserId)
                .HasConversion(
                    v => v.Id,
                    v => new UserId(v))
                .IsRequired();

            builder.Property(b => b.CustomerId)
                .HasConversion(
                    v => v.Id,
                    v => new CustomerId(v))
                .IsRequired();

            builder.Ignore(p => p.Accounts);
        }
    }
}
