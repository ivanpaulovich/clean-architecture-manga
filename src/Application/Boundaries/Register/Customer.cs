// <copyright file="Customer.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Register
{
    using System;
    using System.Collections.Generic;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    /// <summary>
    ///     Customer.
    /// </summary>
    public sealed class Customer
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Customer" /> class.
        /// </summary>
        /// <param name="externalUserId">External User Id.</param>
        /// <param name="customer">Customer object.</param>
        /// <param name="accounts">Accounts list.</param>
        public Customer(
            ExternalUserId externalUserId,
            ICustomer customer,
            List<Account> accounts)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            var customerEntity = (Domain.Customers.Customer)customer;
            this.ExternalUserId = externalUserId;
            this.CustomerId = customerEntity.Id;
            this.SSN = customerEntity.SSN;
            this.Name = customerEntity.Name;
            this.Accounts = accounts;
        }

        /// <summary>
        ///     Gets the External User Id.
        /// </summary>
        public ExternalUserId ExternalUserId { get; }

        /// <summary>
        ///     Gets the Customer Id.
        /// </summary>
        public CustomerId CustomerId { get; }

        /// <summary>
        ///     Gets the SSN.
        /// </summary>
        public SSN SSN { get; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public Name Name { get; }

        /// <summary>
        ///     Gets the Accounts.
        /// </summary>
        public IReadOnlyList<Account> Accounts { get; }
    }
}
