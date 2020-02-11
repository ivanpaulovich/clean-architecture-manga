// <copyright file="Debit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Debits
{
    using System;
    using ValueObjects;

    /// <summary>
    ///     Debit
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">
    ///         Entity
    ///         Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public abstract class Debit : IDebit
    {
        /// <summary>
        ///     Gets or sets Id.
        /// </summary>
        public DebitId Id { get; protected set; }

        /// <summary>
        ///     Gets or sets Amount.
        /// </summary>
        public PositiveMoney Amount { get; protected set; }

        /// <summary>
        ///     Gets Description.
        /// </summary>
        public static string Description
        {
            get => "Debit";
        }

        /// <summary>
        ///     Gets or sets Transaction Date.
        /// </summary>
        public DateTime TransactionDate { get; protected set; }

        /// <summary>
        ///     Calculates the sum of amounts.
        /// </summary>
        /// <param name="amount">Positive amount.</param>
        /// <returns>The positive sum.</returns>
        public PositiveMoney Sum(PositiveMoney amount) => this.Amount.Add(amount);
    }
}
