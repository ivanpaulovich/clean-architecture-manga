namespace MyProject.Infrastructure.EntityFrameworkDataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.Converters;
    using MyProject.Domain.Accounts;
    using MyProject.Domain.Customers;
    using MyProject.Domain.ValueObjects;

    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var nameConverter = new ValueConverter<Name, string>(
                v => v.Text,
                v => new Name(v));

            var pinConverter = new ValueConverter<PIN, string>(
                v => v.Text,
                v => new PIN(v));

            var amountConverter = new ValueConverter<Amount, double>(
                v => v.Value,
                v => new Amount(v));

            modelBuilder.Entity<Account>()
                .ToTable("Account");

            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .Ignore(p => p.Accounts);

            modelBuilder.Entity<Customer>().Property(e => e.Name)
                .HasConversion(nameConverter);

            modelBuilder.Entity<Customer>().Property(e => e.PIN)
                .HasConversion(pinConverter);

            modelBuilder.Entity<Transaction>()
                .ToTable("Transaction")
                .Ignore(p => p.Description)
                .HasDiscriminator<int>("TransactionType")
                .HasValue<Debit>(0)
                .HasValue<Credit>(1);

            modelBuilder.Entity<Transaction>().Property(e => e.Amount)
                .HasConversion(amountConverter);
        }
    }
}
