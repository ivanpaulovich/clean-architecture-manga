// <copyright file="Customer.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.EntityFrameworkDataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;

    /// <summary>
    ///     Customer.
    /// </summary>
    public class Customer : Domain.Customers.Customer
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Customer" /> class.
        /// </summary>
        /// <param name="ssn">SSN.</param>
        /// <param name="name">Name.</param>
        public Customer(
            SSN ssn,
            Name name)
        {
            this.Id = new CustomerId(Guid.NewGuid());
            this.SSN = ssn;
            this.Name = name;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Customer" /> class.
        /// </summary>
        protected Customer()
        {
        }

        /// <summary>
        ///     Load related properties.
        /// </summary>
        /// <param name="accounts">Accounts.</param>
        public void LoadAccounts(IEnumerable<AccountId> accounts)
        {
            this.Accounts = new AccountCollection();
            this.Accounts.Add(accounts);
        }
    }
}
