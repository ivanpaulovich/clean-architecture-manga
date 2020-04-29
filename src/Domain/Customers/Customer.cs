// <copyright file="Customer.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
    using Accounts.ValueObjects;
    using ValueObjects;

    /// <inheritdoc />
    public abstract class Customer : ICustomer
    {
        /// <summary>
        ///     Gets or sets Name.
        /// </summary>
        public abstract Name Name { get; }

        /// <summary>
        ///     Gets or sets SSN.
        /// </summary>
        public abstract SSN SSN { get; }

        /// <inheritdoc />
        public abstract CustomerId Id { get; }

        /// <inheritdoc />
        public abstract AccountCollection Accounts { get; }

        /// <inheritdoc />
        public void Assign(AccountId accountId) => this.Accounts.Add(accountId);
    }
}
