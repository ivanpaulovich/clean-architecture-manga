namespace Infrastructure.InMemoryDataAccess
{
    using System.Collections.Generic;
    using System;
    using Domain.ValueObjects;
    using Domain.Customers;

    public class Customer : Domain.Customers.Customer
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