namespace Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.ValueObjects;
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
