namespace Manga.Domain.Customers
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.ValueObjects;
    using Manga.Domain.Customers.Accounts;
    using System.Linq;

    public class Customer : Entity, IAggregateRoot
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

        protected Customer()
        {
            accounts = new List<Account>();
        }

        public Customer(PIN pin, Name name)
            : this()
        {
            if (pin == null)
                throw new ArgumentNullException(nameof(pin));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            PIN = pin;
            Name = name;
        }

        public virtual void Register(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            accounts.Add(account);
        }

        public virtual void RemoveAccount(Guid accountID)
        {
            Account account = FindAccount(accountID);
            account.Close();
            accounts.Remove(account);
        }

        public virtual Account FindAccount(Guid accountID)
        {
            Account account = Accounts.Where(e => e.Id == accountID).FirstOrDefault();
            return account;
        }
    }
}
