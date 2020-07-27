// <copyright file="Money.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    using System;

    /// <summary>
    ///     Money
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        public Money(decimal amount, Currency currency) =>
            (this.Amount, this.Currency) = (amount, currency);

        public override bool Equals(object? obj) =>
            obj is Money o && this.Equals(o);

        public bool Equals(Money other) =>
            this.Amount == other.Amount &&
            this.Currency == other.Currency;

        public override int GetHashCode() =>
            HashCode.Combine(this.Amount, this.Currency);

        public static bool operator ==(Money left, Money right) => left.Equals(right);

        public static bool operator !=(Money left, Money right) => !(left == right);

        public bool IsZero() => this.Amount == 0;

        public override string ToString() => string.Format($"{this.Amount} {this.Currency}");
    }
}
