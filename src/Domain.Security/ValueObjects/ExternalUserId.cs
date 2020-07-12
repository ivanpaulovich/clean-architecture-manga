// <copyright file="ExternalUserId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security.ValueObjects
{
    using System;

    /// <summary>
    ///     ExternalUserId
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct ExternalUserId : IEquatable<ExternalUserId>
    {
        public string Text { get; }

        public ExternalUserId(string text) =>
            this.Text = text;

        public override bool Equals(object? obj) =>
            obj is ExternalUserId o && this.Equals(o);

        public bool Equals(ExternalUserId other) => this.Text == other.Text;

        public override int GetHashCode() =>
            HashCode.Combine(this.Text);

        public static bool operator ==(ExternalUserId left, ExternalUserId right) => left.Equals(right);

        public static bool operator !=(ExternalUserId left, ExternalUserId right) => !(left == right);

        public override string ToString() => string.Format($"{this.Text}");
    }
}
