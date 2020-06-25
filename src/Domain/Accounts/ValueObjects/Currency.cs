namespace Domain.Accounts.ValueObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Currency
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#value-object">
    ///         Value Object
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct Currency : IEquatable<Currency>
    {
        private static readonly IReadOnlyList<string> allowedCurrencies = new[] { "USD" };

        private readonly string _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Currency" /> struct.
        /// </summary>
        /// <param name="value">String type.</param>
        public Currency(string? value)
        {
            if (string.IsNullOrEmpty(value) || !allowedCurrencies.Contains(value))
                throw new CurrencyNotAllowedException($"\"{value}\" not allowed as a currency.");

            this._value = value;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static Currency Dollar()
        {
            return new Currency("USD");
        }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Currency currencyObj)
            {
                return this.Equals(currencyObj);
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Currency other)
        {
            return this._value == other._value;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => this._value.GetHashCode(StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Currency left, Currency right) => left.Equals(right);

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Currency left, Currency right) => !(left == right);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => this._value;
    }
}
