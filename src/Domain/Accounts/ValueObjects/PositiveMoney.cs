// <copyright file="PositiveMoney.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.ValueObjects
{
    /// <summary>
    /// PositiveMoney <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">Entity Design Pattern</see>.
    /// </summary>
    public readonly struct PositiveMoney
    {
        private readonly Money value;

        /// <summary>
        /// Initializes a new instance of the <see cref="PositiveMoney"/> struct.
        /// </summary>
        /// <param name="value">Decimal amount.</param>
        public PositiveMoney(decimal value)
        {
            if (value < 0)
            {
                throw new MoneyShouldBePositiveException("The 'Amount' should be positive.");
            }

            this.value = new Money(value);
        }

        /// <summary>
        /// Converts into Money Value Object.
        /// </summary>
        /// <returns>Money.</returns>
        public Money ToMoney() => this.value;

        /// <summary>
        /// Adds Money.
        /// </summary>
        /// <param name="positiveAmount">Amount to Add.</param>
        /// <returns>New Instance.</returns>
        internal PositiveMoney Add(PositiveMoney positiveAmount)
        {
            return this.value.Add(positiveAmount.value);
        }

        /// <summary>
        /// Subtracts Money.
        /// </summary>
        /// <param name="positiveAmount">Amount to subtract.</param>
        /// <returns>New Instance.</returns>
        internal Money Subtract(PositiveMoney positiveAmount)
        {
            return this.value.Subtract(positiveAmount.value);
        }
    }
}
