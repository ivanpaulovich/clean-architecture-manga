// <copyright file="Customer.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Entities
{
    using System.Collections.Generic;
    using Common;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;

    /// <inheritdoc />
    public sealed class Customer : Domain.Customers.Customer
    {
        public Customer()
        {
        }

        public Customer(CustomerId id, Name firstName, Name lastName, SSN ssn, UserId userId)
        {
            this.CustomerId = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.UserId = userId;
        }

        /// <inheritdoc />
        public override CustomerId CustomerId { get; }

        /// <summary>
        /// </summary>
        public UserId UserId { get; }

        /// <inheritdoc />
        public override AccountCollection Accounts { get; } = new AccountCollection();

        public User? User { get; set; }

        public ICollection<Account> AccountsCollection { get; } = new List<Account>();
    }
}
