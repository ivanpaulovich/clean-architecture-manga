// <copyright file="Customer.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;

    public class Customer : Domain.Customers.Customer
    {
        public Customer()
        {
        }

        public Customer(SSN ssn, Name name)
        {
            this.Id = new CustomerId(Guid.NewGuid());
            this.SSN = ssn;
            this.Name = name;
        }

        public void LoadAccounts(IEnumerable<AccountId> accounts)
        {
            this.Accounts = new AccountCollection();
            this.Accounts.Add(accounts);
        }
    }
}
