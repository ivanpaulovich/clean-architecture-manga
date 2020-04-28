// <copyright file="ICustomer.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
    using Accounts.ValueObjects;
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
        CustomerId Id { get; }

        /// <summary>
        ///     Gets the Accounts.
        /// </summary>
        AccountCollection Accounts { get; }

        /// <summary>
        ///     Register the Account into the Customer.
        /// </summary>
        /// <param name="accountId">Account Id.</param>
        void Assign(AccountId accountId);
    }
}
