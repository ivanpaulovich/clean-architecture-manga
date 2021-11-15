// <copyright file="CreditId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.ValueObjects;

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
public readonly struct CreditId : IEquatable<CreditId>
{
    public Guid Id { get; }

    public CreditId(Guid id) =>
        this.Id = id;

    public override bool Equals(object? obj) =>
        obj is CreditId o && this.Equals(o);

    public bool Equals(CreditId other) => this.Id == other.Id;

    public override int GetHashCode() =>
        HashCode.Combine(this.Id);

    public static bool operator ==(CreditId left, CreditId right) => left.Equals(right);

    public static bool operator !=(CreditId left, CreditId right) => !(left == right);

    public override string ToString() => this.Id.ToString();
}
