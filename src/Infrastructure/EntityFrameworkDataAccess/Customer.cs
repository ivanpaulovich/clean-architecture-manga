namespace Infrastructure.EntityFrameworkDataAccess
{
    using System.Collections.Generic;
    using System;
    using Domain.Customers;
    using Domain.ValueObjects;

    public class Customer : Domain.Customers.Customer
    {
        protected Customer() { }

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

        public void LoadAccounts(IEnumerable<Guid> accounts)
        {
            Accounts = new AccountCollection();
            Accounts.Add(accounts);
        }
    }
}