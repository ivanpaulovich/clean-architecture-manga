namespace Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain.Customers;
    using Domain.ValueObjects;

    public class Customer : Domain.Customers.Customer
    {
        public Customer(
            ExternalUserId externalUserId,
            SSN ssn,
            Name name)
        {
            Id = Guid.NewGuid();
            ExternalUserId = externalUserId;
            SSN = ssn;
            Name = name;
        }

        protected Customer()
        {
        }

        public void LoadAccounts(IEnumerable<Guid> accounts)
        {
            Accounts = new AccountCollection();
            Accounts.Add(accounts);
        }
    }
}
