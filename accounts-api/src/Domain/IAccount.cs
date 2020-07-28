// <copyright file="IAccount.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain
{
    using Credits;
    using Debits;
    using ValueObjects;

    /// <summary>
    ///     Account
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#aggregate-root">
    ///         Aggregate
    ///         Root Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        ///     Gets Id.
        /// </summary>
        AccountId AccountId { get; }

        /// <summary>
        ///     Deposits into account.
        /// </summary>
        /// <returns>Credit created.</returns>
        void Deposit(Credit credit);

        /// <summary>
        ///     Withdraws from account.
        /// </summary>
        /// <returns>Debit created.</returns>
        void Withdraw(Debit debit);

        /// <summary>
        ///     Check if closing account is allowed.
        /// </summary>
        /// <returns>True if is allowed.</returns>
        bool IsClosingAllowed();

        /// <summary>
        ///     Gets the current balance considering credits and debits totals.
        /// </summary>
        /// <returns>The current balance.</returns>
        Money GetCurrentBalance();
    }
}
