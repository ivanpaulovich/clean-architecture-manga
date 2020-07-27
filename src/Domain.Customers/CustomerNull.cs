// <copyright file="Customer.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
    using System;
    using Common;
    using ValueObjects;

    /// <inheritdoc />
    public sealed class CustomerNull : ICustomer
    {
        public static CustomerNull Instance { get; } = new CustomerNull();

        public CustomerId CustomerId => new CustomerId(Guid.Empty);

        public AccountCollection Accounts => new AccountCollection();

        public void Update(SSN ssn, Name firstName, Name lastName)
        {
            // Null Pattern.
        }
    }
}
