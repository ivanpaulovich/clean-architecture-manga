namespace Manga.Infrastructure.EntityFrameworkDataAccess
{
    using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Entities.Account> Accounts { get; set; }
        public DbSet<Entities.Customer> Customers { get; set; }
        public DbSet<Entities.Credit> Credits { get; set; }
        public DbSet<Entities.Debit> Debits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Account>()
                .ToTable("Account");

            modelBuilder.Entity<Entities.Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Entities.Debit>()
                .ToTable("Debit");

            modelBuilder.Entity<Entities.Credit>()
                .ToTable("Credit");
        }
    }
}
