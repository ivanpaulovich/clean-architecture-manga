namespace Manga.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;

    public sealed class MangaContext : DbContext
    {
        public MangaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Debit> Debits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .ToTable("Account");

            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .Property(b => b.SSN)
                .HasConversion(
                    v => v.ToString(),
                    v => new SSN(v));

            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .Property(b => b.Name)
                .HasConversion(
                    v => v.ToString(),
                    v => new Name(v));

            modelBuilder.Entity<Debit>()
                .ToTable("Debit")
                .Property(b => b.Amount)
                .HasConversion(
                    v => v.ToAmount().ToDouble(),
                    v => new PositiveAmount(v));

            modelBuilder.Entity<Credit>()
                .ToTable("Credit")
                .Property(b => b.Amount)
                .HasConversion(
                    v => v.ToAmount().ToDouble(),
                    v => new PositiveAmount(v));

            modelBuilder.Entity<Customer>().HasData(
                new { Id = new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"), Name = new Name("Test User"), SSN = new SSN("19860817-9999") }
            );

            modelBuilder.Entity<Account>().HasData(
                new { Id = new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"), CustomerId = new Guid("197d0438-e04b-453d-b5de-eca05960c6ae") }
            );

            modelBuilder.Entity<Credit>().HasData(
                new { 
                    Id = new Guid("f5117315-e789-491a-b662-958c37237f9b"),
                    AccountId = new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"),
                    Amount = new PositiveAmount(400),
                    Description = "Credit",
                    TransactionDate = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Debit>().HasData(
                new { 
                    Id = new Guid("3d6032df-7a3b-46e6-8706-be971e3d539f"),
                    AccountId = new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"),
                    Amount = new PositiveAmount(400),
                    Description = "Debit",
                    TransactionDate = DateTime.UtcNow
                }
            );
        }
    }
}