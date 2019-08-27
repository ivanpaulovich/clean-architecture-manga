namespace Manga.Infrastructure.InMemoryGateway
{
    using System.Collections.ObjectModel;
    using System;
    using Manga.Domain.ValueObjects;

    public sealed class MangaContext
    {
        public Collection<Customer> Customers { get; set; }
        public Collection<Account> Accounts { get; set; }
        public Collection<Credit> Credits { get; set; }
        public Collection<Debit> Debits { get; set; }

        public Guid DefaultCustomerId { get; }
        public Guid DefaultAccountId { get; }

        public Guid SecondCustomerId { get; }
        public Guid SecondAccountId { get; }

        public MangaContext()
        {
            var entityFactory = new EntityFactory();
            Customers = new Collection<Customer>();
            Accounts = new Collection<Account>();
            Credits = new Collection<Credit>();
            Debits = new Collection<Debit>();

            var customer = new Customer(new SSN("8608179999"), new Name("Ivan Paulovich"));
            var account = new Account(customer);
            var credit = account.Deposit(entityFactory, new PositiveAmount(800));
            var debit = account.Withdraw(entityFactory, new PositiveAmount(100));
            customer.Register(account);

            Customers.Add(customer);
            Accounts.Add(account);
            Credits.Add((Credit) credit);
            Debits.Add((Debit) debit);

            DefaultCustomerId = customer.Id;
            DefaultAccountId = account.Id;

            var secondCustomer = new Customer(new SSN("8408319999"), new Name("Andre Paulovich"));
            var secondAccount = new Account(secondCustomer);

            Customers.Add(secondCustomer);
            Accounts.Add(secondAccount);

            SecondCustomerId = secondCustomer.Id;
            SecondAccountId = secondAccount.Id;
        }
    }
}