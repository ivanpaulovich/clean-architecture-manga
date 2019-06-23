namespace Manga.Domain.Customers
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.ValueObjects;

    public class Customer : ICustomer
    { 
        public Guid Id { get; protected set; }
        public Name Name { get; protected set; }
        public SSN SSN { get; protected set; }
        public IReadOnlyCollection<Guid> Accounts
        {
            get
            {
                IReadOnlyCollection<Guid> readOnly = _accounts.GetAccountIds();
                return readOnly;
            }
        }

        private AccountCollection _accounts = new AccountCollection();

        public void Register(Guid accountId)
        {
            _accounts.Add(accountId);
        }

        private Customer() { }

        public Customer(SSN ssn, Name name)
        {
            Id = Guid.NewGuid();
            SSN = ssn;
            Name = name;
        }

        public void LoadAccounts(ICollection<Guid> accountIds)
        {
            _accounts = new AccountCollection();
            foreach(var account in accountIds)
                _accounts.Add(account);
        }
    }
}