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
        private readonly Money _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PositiveMoney" /> struct.
        /// </summary>
        /// <param name="value">Decimal amount.</param>
        /// <param name="currency">Currency type.</param>
        public PositiveMoney(decimal value, string? currency = "USD")
        {
            if (value < 0)
            {
                throw new MoneyShouldBePositiveException(Messages.TheAmountShouldBePositive);
            }

            Currency tempCurrency = new Currency(currency);
            this._value = new Money(value, tempCurrency);
        }

        /// <summary>
        ///     Converts into Money Value Object.
        /// </summary>
        /// <returns>Money.</returns>
        public Money ToMoney() => this._value;

        /// <summary>
        ///     Adds Money.
        /// </summary>
        /// <param name="positiveAmount">Amount to Add.</param>
        /// <returns>New Instance.</returns>
        internal PositiveMoney Add(PositiveMoney positiveAmount) => this._value.Add(positiveAmount._value);

        /// <summary>
        ///     Subtracts Money.
        /// </summary>
        /// <param name="positiveAmount">Amount to subtract.</param>
        /// <returns>New Instance.</returns>
        internal Money Subtract(PositiveMoney positiveAmount) => this._value.Subtract(positiveAmount._value);

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is PositiveMoney positiveMoneyObj)
            {
                return this.Equals(positiveMoneyObj);
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => this._value.GetHashCode();

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(PositiveMoney left, PositiveMoney right) => left.Equals(right);

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(PositiveMoney left, PositiveMoney right) => !(left == right);

        /// <summary>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(PositiveMoney other) => this._value.ToDecimal() == other._value.ToDecimal();

        /// <summary>
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public bool IsCurrencyEqualsTo(string currency) => this._value.GetCurrency().ToString() == currency;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public Currency GetCurrency() => this._value.GetCurrency();
    }
}
