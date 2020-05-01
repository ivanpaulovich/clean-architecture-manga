// <copyright file="User.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security
{
    using Customers.ValueObjects;

    /// <inheritdoc />
    public abstract class User : IUser
    {
        /// <inheritdoc />
        public abstract Name Name { get; }

        /// <inheritdoc />
        public abstract CustomerId? CustomerId { get; protected set; }

        /// <inheritdoc />
        public void Assign(CustomerId customerId) => this.CustomerId = customerId;
    }
}
