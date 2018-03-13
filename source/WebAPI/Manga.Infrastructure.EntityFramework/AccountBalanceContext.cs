
namespace Manga.Infrastructure.EntityFramework
{
    using JetBrains.Annotations;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountBalanceContext : DbContext
    {
        public AccountBalanceContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set ; }
        public DbSet<Customer> Customers { get ; set ; }
    }
}
