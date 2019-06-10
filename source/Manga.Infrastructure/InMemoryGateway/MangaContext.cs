namespace Manga.Infrastructure.InMemoryDataAccess
{
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using System.Collections.ObjectModel;

    public class MangaContext
    {
        public Collection<Customer> Customers { get; set; }
        public Collection<Account> Accounts { get; set; }
        public Collection<Credit> Credits { get; set; }
        public Collection<Debit> Debits { get; set; }

        public MangaContext()
        {
            Customers = new Collection<Customer>();
            Accounts = new Collection<Account>();
            Credits = new Collection<Credit>();
            Debits = new Collection<Debit>();
        }
    }
}
