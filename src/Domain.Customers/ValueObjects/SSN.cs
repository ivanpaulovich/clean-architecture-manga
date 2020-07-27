// <copyright file="SSN.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers.ValueObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     SSN
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "<Pending>")]
    public readonly struct SSN : IEquatable<SSN>
    {
        public string Text { get; }

        public SSN(string text) =>
            this.Text = text;

        public override bool Equals(object? obj) =>
            obj is SSN o && this.Equals(o);

        public bool Equals(SSN other) => this.Text == other.Text;

        public override int GetHashCode() =>
            HashCode.Combine(this.Text);

        public static bool operator ==(SSN left, SSN right) => left.Equals(right);

        public static bool operator !=(SSN left, SSN right) => !(left == right);

        public override string ToString() => string.Format($"{this.Text}");
    }
}
