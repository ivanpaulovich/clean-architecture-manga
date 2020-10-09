// <copyright file="CreditNull.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Credits
{
    using System;
    using ValueObjects;

    /// <summary>
    ///     Credit
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class CreditNull : ICredit
    {
        public static CreditNull Instance { get; } = new CreditNull();
        public CreditId CreditId { get; } = new CreditId(Guid.Empty);
        public Money Amount { get; } = new Money(0, new Currency(string.Empty));
    }
}
