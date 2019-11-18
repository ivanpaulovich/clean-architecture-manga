namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain.Customers;
    using Domain.ValueObjects;

    public class Customer : Domain.Customers.Customer
    {
        public Customer()
        {
        }

        public Customer(ExternalUserId externalUserId, SSN ssn, Name name)
        {
            Id = Guid.NewGuid();
            ExternalUserId = externalUserId;
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