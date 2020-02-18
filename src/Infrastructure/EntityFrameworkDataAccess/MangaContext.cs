// <copyright file="MangaContext.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.EntityFrameworkDataAccess
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public sealed class MangaContext : DbContext
    {
        public MangaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Account> Accounts { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Credit> Credits { get; set; } = null!;

        public DbSet<Debit> Debits { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(MangaContext).Assembly);
            SeedData.Seed(builder);
        }
    }
}
