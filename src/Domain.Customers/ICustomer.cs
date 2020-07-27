// <copyright file="ICustomer.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
    using Common;
    using ValueObjects;

    /// <summary>
    ///     Customer
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#aggregate-root">
    ///         Aggregate
    ///         Root Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        ///     Gets the CustomerId.
        /// </summary>
        CustomerId CustomerId { get; }

        /// <summary>
        ///     Gets the Accounts.
        /// </summary>
        AccountCollection Accounts { get; }

        /// <summary>
        /// </summary>
        /// <param name="ssn"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        void Update(SSN ssn, Name firstName, Name lastName);
    }
}
