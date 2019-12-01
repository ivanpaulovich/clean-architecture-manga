namespace Infrastructure.InMemoryDataAccess
{
    using System.Collections.ObjectModel;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.ValueObjects;

    public sealed class MangaContext
    {
        public MangaContext()
        {
            var entityFactory = new EntityFactory();
            Customers = new Collection<Customer>();
            Accounts = new Collection<Account>();
            Credits = new Collection<Credit>();
            Debits = new Collection<Debit>();
            Users = new Collection<User>();

            var customer = new Customer(
                new SSN("8608179999"),
                new Name("Ivan Paulovich"));
            var user1 = new User(
                customer,
                new ExternalUserId("github/ivanpaulovich"));
            var account = new Account(customer);
            var credit = account.Deposit(
                entityFactory,
                new PositiveMoney(800));
            var debit = account.Withdraw(
                entityFactory,
                new PositiveMoney(100));
            customer.Register(account);

            Customers.Add(customer);
            Accounts.Add(account);
            Credits.Add((Credit)credit);
            Debits.Add((Debit)debit);
            Users.Add(user1);

            DefaultCustomerId = customer.Id;
            DefaultAccountId = account.Id;

            var secondCustomer = new Customer(
                new SSN("8408319999"),
                new Name("Andre Paulovich"));
            var secondUser = new User(
                secondCustomer,
                new ExternalUserId("github/andrepaulovich"));
            var secondAccount = new Account(secondCustomer);

            Customers.Add(secondCustomer);
            Accounts.Add(secondAccount);
            Users.Add(secondUser);

            SecondCustomerId = secondCustomer.Id;
            SecondAccountId = secondAccount.Id;
        }

        public Collection<User> Users { get; set; }

        public Collection<Customer> Customers { get; set; }

        public Collection<Account> Accounts { get; set; }

        public Collection<Credit> Credits { get; set; }

        public Collection<Debit> Debits { get; set; }

        public CustomerId DefaultCustomerId { get; }

        public AccountId DefaultAccountId { get; }

        public CustomerId SecondCustomerId { get; }

        public AccountId SecondAccountId { get; }
    }
}
