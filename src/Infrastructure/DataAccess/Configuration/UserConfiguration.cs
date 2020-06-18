// <copyright file="UserConfiguration.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Configuration
{
    using System;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     User Configuration.
    /// </summary>
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        ///     Configure User.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("User");

            builder.Property(b => b.ExternalUserId)
                .HasConversion(
                    v => v.ToString(),
                    v => new ExternalUserId(v))
                .IsRequired();

            builder.Property(b => b.CustomerId)
                .HasConversion(
                    v => v.HasValue ? v.Value.ToGuid() : Guid.Empty,
                    v => new CustomerId(v))
                .IsRequired();

            builder.HasKey(
                c => new {c.ExternalUserId, c.CustomerId});
        }
    }
}
