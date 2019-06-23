namespace Manga.Infrastructure.InMemoryDataAccess
{
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;
    using System;
    using System.Collections.ObjectModel;

    public sealed class MangaContext
    {
        public Collection<Customer> Customers { get; set; }
        public Collection<Account> Accounts { get; set; }
        public Collection<Credit> Credits { get; set; }
        public Collection<Debit> Debits { get; set; }

        public Guid DefaultCustomerId { get; }
        public Guid DefaultAccountId { get; }


        public MangaContext()
        {
            Customers = new Collection<Customer>();
            Accounts = new Collection<Account>();
            Credits = new Collection<Credit>();
            Debits = new Collection<Debit>();

            var customer = new Customer(new SSN("8608179999"), new Name("Ivan Paulovich"));
            var account = new Account(customer.Id);
            var credit = account.Deposit(new PositiveAmount(800));
            var debit = account.Withdraw(new PositiveAmount(100));
            customer.Register(account.Id);

            Customers.Add(customer);
            Accounts.Add(account);
            Credits.Add((Credit)credit);
            Debits.Add((Debit)debit);

            DefaultCustomerId = customer.Id;
            DefaultAccountId = account.Id;
        }
    }
}
