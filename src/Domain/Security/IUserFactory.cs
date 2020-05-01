// <copyright file="IUserFactory.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security
{
    using Customers.ValueObjects;
    using ValueObjects;

    /// <summary>
    ///     User
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity-factory">
    ///         Entity
    ///         Factory Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface IUserFactory
    {
        /// <summary>
        ///     Creates new User.
        /// </summary>
        /// s
        /// <param name="customer">Customer object.</param>
        /// <param name="externalUserId">ExternalUserId.</param>
        /// <param name="name">Name.</param>
        /// <returns>New User instance.</returns>
        IUser NewUser(CustomerId? customer, ExternalUserId externalUserId, Name name);
    }
}
