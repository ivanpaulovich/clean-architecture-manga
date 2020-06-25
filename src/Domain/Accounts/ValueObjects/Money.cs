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
        private readonly Currency _currency;

        private readonly decimal _money;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Money" /> struct.
        /// </summary>
        /// <param name="value">Decimal amount.</param>
        /// <param name="currency">The currency used, default is USD.</param>
        public Money(decimal value, Currency currency = default)
        {
            this._currency = currency == default ? Currency.Dollar : currency;
            this._money = value;
        }

        /// <summary>
        ///     Converts into decimal.
        /// </summary>
        /// <returns>decimal amount.</returns>
        public decimal ToDecimal() => this._money;

        /// <summary>
        ///     Less than amount.
        /// </summary>
        /// <param name="amount">Amount.</param>
        /// <returns>True if it is less.</returns>
        internal bool LessThan(PositiveMoney amount) => this._money < amount.ToMoney()._money;

        /// <summary>
        ///     Returns true if is zero.
        /// </summary>
        /// <returns>True if zero.</returns>
        internal bool IsZero() => this._money == 0;

        /// <summary>
        ///     Adds Money.
        /// </summary>
        /// <param name="value">Amount to check.</param>
        /// <returns>New Instance.</returns>
        internal PositiveMoney Add(Money value) => new PositiveMoney(this._money + value.ToDecimal());

        /// <summary>
        ///     Subtracts amount.
        /// </summary>
        /// <param name="value">Amount to subtract.</param>
        /// <returns>New Instance.</returns>
        internal Money Subtract(Money value) => new Money(this._money - value.ToDecimal());

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Money moneyObj)
            {
                return this.Equals(moneyObj);
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => this._money.GetHashCode();

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Money left, Money right) => left.Equals(right);

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Money left, Money right) => !(left == right);

        /// <summary>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Money other) => this._money == other._money;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public Currency GetCurrency() => this._currency;
    }
}
