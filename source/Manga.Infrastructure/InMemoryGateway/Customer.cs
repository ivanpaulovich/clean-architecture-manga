namespace Manga.Infrastructure.InMemoryGateway
{
    using System;
    using System.Collections.Generic;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;

    public class Customer : Manga.Domain.Customers.Customer
    {
        public Customer() { }

        public Customer(SSN ssn, Name name)
        {
            Id = Guid.NewGuid();
            SSN = ssn;
            Name = name;
        }

        public void LoadAccounts(IEnumerable<Guid> accounts)
        {
            Accounts = new AccountCollection();
            Accounts.Add(accounts);
        }
    }
}