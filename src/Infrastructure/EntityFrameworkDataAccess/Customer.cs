namespace Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;

    public class Customer : Domain.Customers.Customer
    {
        public Customer(
            SSN ssn,
            Name name)
        {
            Id = new CustomerId(Guid.NewGuid());
            SSN = ssn;
            Name = name;
        }

        protected Customer()
        {
        }

        public void LoadAccounts(IEnumerable<AccountId> accounts)
        {
            Accounts = new AccountCollection();
            Accounts.Add(accounts);
        }
    }
}
