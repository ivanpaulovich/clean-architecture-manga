namespace Infrastructure.InMemoryDataAccess
{
    using System.Collections.Generic;
    using System;
    using Domain.Customers;
    using Domain.ValueObjects;

    public class Customer : Domain.Customers.Customer
    {
        public Customer() { }

        public Customer(SSN ssn, Name name, Username username, Password password)
        {
            Id = Guid.NewGuid();
            SSN = ssn;
            Name = name;
            Username = username;
            Password = password;
        }

        public void LoadAccounts(IEnumerable<Guid> accounts)
        {
            Accounts = new AccountCollection();
            Accounts.Add(accounts);
        }
    }
}
