namespace Manga.Domain.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Manga.Domain.ValueObjects;

    public sealed class Customer : IEntity, IAggregateRoot
    {
        public Guid Id { get; }
        public Name Name { get; }
        public SSN SSN { get; }
        public ReadOnlyCollection<Guid> Accounts
        {
            get
            {
                ReadOnlyCollection<Guid> readOnly = new ReadOnlyCollection<Guid>(_accounts);
                return readOnly;
            }
        }

        private AccountCollection _accounts;

        public Customer(Guid id, Name name, SSN ssn, AccountCollection accounts)
        {
            Id = id;
            Name = name;
            SSN = ssn;
            _accounts = accounts;
        }

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
    }
}
