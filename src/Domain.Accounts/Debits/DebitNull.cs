// <copyright file="DebitNull.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Debits
{
    using System;
    using ValueObjects;

    /// <summary>
    ///     Debit
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class DebitNull : IDebit
    {
        public static DebitNull Instance { get; } = new DebitNull();
        public DebitId DebitId { get; } = new DebitId(Guid.Empty);
        public PositiveMoney Amount { get; } = new PositiveMoney(0, new Currency(string.Empty));
    }
}
