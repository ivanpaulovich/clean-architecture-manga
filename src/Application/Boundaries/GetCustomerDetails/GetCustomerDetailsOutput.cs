// <copyright file="GetCustomerDetailsOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetCustomerDetails
{
    using System;
    using System.Collections.Generic;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    /// <summary>
    ///     Gets Customer Details Output Message.
    /// </summary>
    public sealed class GetCustomerDetailsOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetCustomerDetailsOutput" /> class.
        /// </summary>
        /// <param name="externalUserId">External User Id.</param>
        /// <param name="customer">Customer object.</param>
        /// <param name="accounts">Accounts list.</param>
        public GetCustomerDetailsOutput(
            ExternalUserId externalUserId,
            ICustomer customer,
            List<Account> accounts)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            Customer customerEntity = (Customer)customer;
            this.ExternalUserId = externalUserId;
            this.CustomerId = customerEntity.Id;
            this.SSN = customerEntity.SSN;
            this.Name = customerEntity.Name;
            this.Accounts = accounts;
        }

        /// <summary>
        ///     Gets the ExternalUserId.
        /// </summary>
        public ExternalUserId ExternalUserId { get; }

        /// <summary>
        ///     Gets the CustomerId.
        /// </summary>
        public CustomerId CustomerId { get; }

        /// <summary>
        ///     Gets the SSN.
        /// </summary>
        public SSN SSN { get; }

        /// <summary>
        ///     Gets the Name.
        /// </summary>
        public Name Name { get; }

        /// <summary>
        ///     Gets the Accounts.
        /// </summary>
        public IReadOnlyList<Account> Accounts { get; }
    }
}
