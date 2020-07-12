// <copyright file="IUserFactory.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security
{
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
        /// <param name="externalUserId">ExternalUserId.</param>
        /// <returns>New User instance.</returns>
        User NewUser(ExternalUserId externalUserId);
    }
}
