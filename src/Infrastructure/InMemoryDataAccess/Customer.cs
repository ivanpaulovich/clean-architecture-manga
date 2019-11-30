namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Customers;

    public class Customer : Domain.Customers.Customer
    {
        public Customer()
        {
        }

        public Customer(SSN ssn, Name name)
        {
            Id = new CustomerId(Guid.NewGuid());
            SSN = ssn;
            Name = name;
        }

        public void LoadAccounts(IEnumerable<AccountId> accounts)
        {
            Accounts = new AccountCollection();
            Accounts.Add(accounts);
        }
    }
}
