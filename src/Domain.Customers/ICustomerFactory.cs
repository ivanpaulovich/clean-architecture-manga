// <copyright file="ICustomerFactory.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
    using Common;
    using ValueObjects;

    /// <summary>
    ///     Customer
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity-factory">
    ///         Entity
    ///         Factory Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface ICustomerFactory
    {
        /// <summary>
        ///     Creates a new Customer.
        /// </summary>
        /// <param name="ssn">SSN.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="userId"></param>
        /// <returns>New Customer instance.</returns>
        Customer NewCustomer(SSN ssn, Name firstName, Name lastName, UserId userId);
    }
}
