namespace Domain.Accounts.ValueObjects
{
    using System;

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
        private readonly string _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Currency" /> struct.
        /// </summary>
        /// <param name="value">String type.</param>
        private Currency(string value)
        {
            this._value = value;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Currency" /> with Dollar struct.
        /// </summary>
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
        /// <param name="currency"></param>
        /// <returns></returns>
        public static Currency Create(string? currency)
        {
            if (currency == "USD") return Dollar();

            throw new CurrencyNotFoundException($"{currency} not implemented yet.");
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
