namespace Manga.Domain.Customers
{
    using System;
    using System.Collections.Generic;
    using Manga.Domain.ValueObjects;

    public sealed class Customer : IEntity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public SSN SSN { get; private set; }
        public IReadOnlyCollection<Guid> Accounts
        {
            get
            {
                IReadOnlyCollection<Guid> readOnly = _accounts.GetAccountIds();
                return readOnly;
            }
        }

        private AccountCollection _accounts;       
                
        public Customer(SSN ssn, Name name)
        {
            Id = Guid.NewGuid();
            SSN = ssn;
            Name = name;
            _accounts = new AccountCollection();
        }

        public void Register(Guid accountId)
        {
            _accounts.Add(accountId);
        }

        private Customer() { }

        public static Customer Load(Guid id, Name name, SSN ssn, AccountCollection accounts)
        {
            Customer customer = new Customer();
            customer.Id = id;
            customer.Name = name;
            customer.SSN = ssn;
            customer._accounts = accounts;
            return customer;
        }
    }
}
