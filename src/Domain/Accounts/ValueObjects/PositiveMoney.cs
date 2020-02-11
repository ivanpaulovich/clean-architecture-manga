// <copyright file="PositiveMoney.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    using System;

    /// <summary>
    ///     PositiveMoney
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public readonly struct PositiveMoney : IEquatable<PositiveMoney>
    {
        private readonly Money value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PositiveMoney" /> struct.
        /// </summary>
        /// <param name="value">Decimal amount.</param>
        public PositiveMoney(decimal value)
        {
            if (value < 0)
            {
                throw new MoneyShouldBePositiveException(Messages.TheAmountShouldBePositive);
            }

            this.value = new Money(value);
        }

        /// <summary>
        ///     Converts into Money Value Object.
        /// </summary>
        /// <returns>Money.</returns>
        public Money ToMoney() => this.value;

        /// <summary>
        ///     Adds Money.
        /// </summary>
        /// <param name="positiveAmount">Amount to Add.</param>
        /// <returns>New Instance.</returns>
        internal PositiveMoney Add(PositiveMoney positiveAmount)
        {
            return this.value.Add(positiveAmount.value);
        }

        /// <summary>
        ///     Subtracts Money.
        /// </summary>
        /// <param name="positiveAmount">Amount to subtract.</param>
        /// <returns>New Instance.</returns>
        internal Money Subtract(PositiveMoney positiveAmount)
        {
            return this.value.Subtract(positiveAmount.value);
        }

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
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(PositiveMoney left, PositiveMoney right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(PositiveMoney left, PositiveMoney right)
        {
            return !(left == right);
        }

        /// <summary>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(PositiveMoney other)
        {
            return this.value.ToDecimal() == other.value.ToDecimal();
        }
    }
}
