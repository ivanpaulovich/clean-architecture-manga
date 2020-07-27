// <copyright file="IUser.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security
{
    using Common;
    using ValueObjects;

    /// <summary>
    ///     User
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#aggregate-root">
    ///         Aggregate
    ///         Root Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface IUser
    {
        /// <summary>
        ///     Gets the ExternalUserId.
        /// </summary>
        ExternalUserId ExternalUserId { get; }

        UserId UserId { get; }
    }
}
