// <copyright file="MangaContext.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess
{
    using System;
    using Domain;
    using Domain.Credits;
    using Domain.Debits;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public sealed class MangaContext : DbContext
    {
        /// <summary>
        /// </summary>
        /// <param name="options"></param>
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public MangaContext(DbContextOptions options)
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
            : base(options)
        {
        }

        /// <summary>
        ///     Gets or sets Accounts
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        ///     Gets or sets Credits
        /// </summary>
        public DbSet<Credit> Credits { get; set; }

        /// <summary>
        ///     Gets or sets Debits
        /// </summary>
        public DbSet<Debit> Debits { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MangaContext).Assembly);
            SeedData.Seed(modelBuilder);
        }
    }
}
