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

        public CustomerId DefaultCustomerId { get; set; } = new CustomerId(new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"));

        public AccountId DefaultAccountId { get; set; } = new AccountId(new Guid("4c510cfe-5d61-4a46-a3d9-c4313426655f"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .ToTable("Account");

            modelBuilder.Entity<Account>()
                .Property(b => b.Id)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new AccountId(v))
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(b => b.CustomerId)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new CustomerId(v))
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Ignore(p => p.Credits)
                .Ignore(p => p.Debits);

            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .Property(b => b.SSN)
                .HasConversion(
                    v => v.ToString(),
                    v => new SSN(v))
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(b => b.Name)
                .HasConversion(
                    v => v.ToString(),
                    v => new Name(v))
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(b => b.Id)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new CustomerId(v))
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Ignore(p => p.Accounts);

            modelBuilder.Entity<Debit>()
                .ToTable("Debit")
                .Property(b => b.Amount)
                .HasConversion(
                    v => v.ToMoney().ToDecimal(),
                    v => new PositiveMoney(v))
                .IsRequired();

            modelBuilder.Entity<Debit>()
                .Property(b => b.Id)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new DebitId(v))
                .IsRequired();

            modelBuilder.Entity<Debit>()
                .Property(b => b.AccountId)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new AccountId(v))
                .IsRequired();

            modelBuilder.Entity<Credit>()
                .ToTable("Credit")
                .Property(b => b.Amount)
                .HasConversion(
                    v => v.ToMoney().ToDecimal(),
                    v => new PositiveMoney(v))
                .IsRequired();

            modelBuilder.Entity<Credit>()
                .Property(b => b.Id)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new CreditId(v))
                .IsRequired();

            modelBuilder.Entity<Credit>()
                .Property(b => b.AccountId)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new AccountId(v))
                .IsRequired();

            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<User>()
                .Property(b => b.ExternalUserId)
                .HasConversion(
                    v => v.ToString(),
                    v => new ExternalUserId(v))
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.CustomerId)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new CustomerId(v))
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasKey(
                    c => new
                    {
                        c.ExternalUserId,
                        c.CustomerId
                    }
                );

            modelBuilder.Entity<Customer>().HasData(
                new
                {
                    Id = DefaultCustomerId,
                    Name = new Name("Test User"),
                    SSN = new SSN("19860817-9999"),
                });

            modelBuilder.Entity<Account>().HasData(
                new
                {
                    Id = DefaultAccountId,
                    CustomerId = DefaultCustomerId,
                });

            modelBuilder.Entity<Credit>().HasData(
                new
                {
                    Id = new CreditId(new Guid("f5117315-e789-491a-b662-958c37237f9b")),
                    AccountId = DefaultAccountId,
                    Amount = new PositiveMoney(400),
                    Description = "Credit",
                    TransactionDate = DateTime.UtcNow,
                });

            modelBuilder.Entity<Debit>().HasData(
                new
                {
                    Id = new DebitId(new Guid("3d6032df-7a3b-46e6-8706-be971e3d539f")),
                    AccountId = DefaultAccountId,
                    Amount = new PositiveMoney(400),
                    Description = "Debit",
                    TransactionDate = DateTime.UtcNow,
                });

            modelBuilder.Entity<User>().HasData(
                new
                {
                    CustomerId = DefaultCustomerId,
                    ExternalUserId = new ExternalUserId("github/ivanpaulovich")
                });
        }
    }
}
