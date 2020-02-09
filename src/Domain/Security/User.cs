// <copyright file="User.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    /// <inheritdoc/>
    public abstract class User : IUser
    {
        /// <inheritdoc/>
        public ExternalUserId ExternalUserId { get; set; }

        /// <inheritdoc/>
        public CustomerId CustomerId { get; set; }
    }
}
