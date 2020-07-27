// <copyright file="CreditId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Common
{
    using System;

    /// <summary>
    ///     CreditId
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#value-object">
    ///         Value
    ///         Object Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct UserId : IEquatable<UserId>
    {
        public Guid Id { get; }

        public UserId(Guid id) =>
            this.Id = id;

        public override bool Equals(object? obj) =>
            obj is UserId o && this.Equals(o);

        public bool Equals(UserId other) => this.Id == other.Id;

        public override int GetHashCode() =>
            HashCode.Combine(this.Id);

        public static bool operator ==(UserId left, UserId right) => left.Equals(right);

        public static bool operator !=(UserId left, UserId right) => !(left == right);

        public override string ToString() => this.Id.ToString();
    }
}
