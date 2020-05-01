// <copyright file="User.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Entities
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    /// <summary>
    ///     User.
    /// </summary>
    public sealed class User : Domain.Security.User
    {
        public User()
        {
        }

        public User(ExternalUserId externalUserId, Name name, CustomerId? customerId)
        {
            this.ExternalUserId = externalUserId;
            this.Name = name;
            this.CustomerId = customerId;
        }

        /// <inheritdoc />
        public ExternalUserId ExternalUserId { get; }

        /// <inheritdoc />
        public override Name Name { get; }

        /// <inheritdoc />
        public override CustomerId? CustomerId { get; protected set; }
    }
}
