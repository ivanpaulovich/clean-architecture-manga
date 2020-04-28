// <copyright file="MangaContext.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public sealed class MangaContext : DbContext
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="options"></param>
        public MangaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<Debit> Debits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(MangaContext).Assembly);
            SeedData.Seed(builder);
        }
    }
}
