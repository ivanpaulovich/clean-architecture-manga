namespace Manga.Domain.Customers
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.ValueObjects;
    using Manga.Domain.Accounts;
    using System.Linq;

    public class Customer : AggregateRoot
    {
        public Name Name { get; private set; }
        public PIN PIN { get; private set; }

        private List<Account> accounts;
        public IReadOnlyCollection<Account> Accounts
        {
            get
            {
                return accounts.AsReadOnly();
            }
            private set
            {
                accounts = value.ToList();
            }
        }

        public Customer()
        {
            accounts = new List<Account>();
        }

        public static Customer Create(PIN pin, Name name)
        {
            if (pin == null)
                throw new ArgumentNullException(nameof(pin));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Customer customer = new Customer();
            customer.PIN = pin;
            customer.Name = name;

            return customer;
        }

        public void Register(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            accounts.Add(account);
        }

        public void RemoveAccount(Guid accountID)
        {
            Account account = FindAccount(accountID);
            accounts.Remove(account);
        }

        public Account FindAccount(Guid accountID)
        {
            Account account = Accounts.Where(e => e.Id == accountID).First();
            return account;
        }
    }
}
