// <copyright file="Credit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Credits
{
    using System;
    using ValueObjects;

    /// <summary>
    ///     Credit
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public abstract class Credit : ICredit
    {
        /// <summary>
        ///     Gets or sets Id.
        /// </summary>
        public CreditId Id { get; protected set; }

        /// <summary>
        ///     Gets or sets Amount.
        /// </summary>
        public PositiveMoney Amount { get; protected set; }

        /// <summary>
        ///     Gets Description.
        /// </summary>
        public static string Description
        {
            get { return "Credit"; }
        }

        /// <summary>
        ///     Gets or sets Transaction Date.
        /// </summary>
        public DateTime TransactionDate { get; protected set; }

        /// <summary>
        ///     Calculate the sum of positive amounts.
        /// </summary>
        /// <param name="amount">Positive amount.</param>
        /// <returns>The positive sum.</returns>
        public PositiveMoney Sum(PositiveMoney amount)
        {
            return this.Amount.Add(amount);
        }
    }
}
