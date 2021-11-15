namespace Domain.ValueObjects;

using System;

/// <summary>
///     Currency
///     <see
///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#value-object">
///         Value Object
///         Design Pattern
///     </see>
///     .
/// </summary>
public readonly struct Currency : IEquatable<Currency>
{
    public string Code { get; }

    public Currency(string code) =>
        this.Code = code;

    public override bool Equals(object? obj) =>
        obj is Currency o && this.Equals(o);

    public bool Equals(Currency other) => this.Code == other.Code;

    public override int GetHashCode() =>
        HashCode.Combine(this.Code);

    public static bool operator ==(Currency left, Currency right) => left.Equals(right);

    public static bool operator !=(Currency left, Currency right) => !(left == right);

    /// <summary>
    ///     Dollar.
    /// </summary>
    /// <returns>Currency.</returns>
    public static readonly Currency Dollar = new Currency("USD");

    /// <summary>
    ///     Euro.
    /// </summary>
    /// <returns>Currency.</returns>
    public static readonly Currency Euro = new Currency("EUR");

    /// <summary>
    ///     British Pound.
    /// </summary>
    /// <returns>Currency.</returns>
    public static readonly Currency BritishPound = new Currency("GBP");

    /// <summary>
    ///     Canadian Dollar.
    /// </summary>
    /// <returns>Currency.</returns>
    public static readonly Currency Canadian = new Currency("CAD");

    /// <summary>
    ///     Brazilian Real.
    /// </summary>
    /// <returns>Currency.</returns>
    public static readonly Currency Real = new Currency("BRL");

    /// <summary>
    ///     Swedish Krona.
    /// </summary>
    /// <returns>Currency.</returns>
    public static readonly Currency Krona = new Currency("SEK");

    public override string ToString() => this.Code;
}
