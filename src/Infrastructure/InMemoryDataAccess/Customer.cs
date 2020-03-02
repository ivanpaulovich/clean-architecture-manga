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

    public sealed class Customer : Domain.Customers.Customer
    {
        public Customer(CustomerId customerId, SSN ssn, Name name, IEnumerable<AccountId> accounts)
        {
            this.Id = customerId;
            this.SSN = ssn;
            this.Name = name;
            this.Accounts = new AccountCollection();
            this.Accounts.Add(accounts);
        }
    }
}
