namespace Manga.Infrastructure.InMemoryDataAccess
{
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using System.Collections.ObjectModel;

    public class Context
    {
        public Collection<Customer> Customers { get; set; }
        public Collection<Account> Accounts { get; set; }

        public Context()
        {
            Customers = new Collection<Customer>();
            Accounts = new Collection<Account>();
        }
    }
}
