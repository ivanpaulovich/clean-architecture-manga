// <copyright file="PositiveMoney.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    using System;

    /// <summary>
    ///     PositiveMoney
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#value-object">
    ///         Value Object
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct PositiveMoney : IEquatable<PositiveMoney>
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        public PositiveMoney(decimal amount, Currency currency) =>
            (this.Amount, this.Currency) = (amount, currency);

        public override bool Equals(object? obj) =>
            obj is PositiveMoney o && this.Equals(o);

        public bool Equals(PositiveMoney other) =>
            this.Amount == other.Amount &&
            this.Currency == other.Currency;

        public override int GetHashCode() =>
            HashCode.Combine(this.Amount, this.Currency);

        public static bool operator ==(PositiveMoney left, PositiveMoney right) => left.Equals(right);

        public static bool operator !=(PositiveMoney left, PositiveMoney right) => !(left == right);

        public Money Subtract(PositiveMoney totalDebits) =>
            new Money(Math.Round(this.Amount - totalDebits.Amount, 2), this.Currency);

        public Money Add(Money amount) => new Money(Math.Round(this.Amount + amount.Amount, 2), this.Currency);

        public override string ToString() => string.Format($"{this.Amount} {this.Currency}");
    }
}
