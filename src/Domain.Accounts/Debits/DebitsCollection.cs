// <copyright file="DebitsCollection.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Debits
{
    using System.Collections.Generic;
    using System.Linq;
    using ValueObjects;

    /// <summary>
    ///     Debits
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#first-class-collections">
    ///         First-Class
    ///         Collection Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class DebitsCollection : List<IDebit>
    {
        /// <summary>
        ///     Gets Total amount.
        /// </summary>
        /// <returns>Total.</returns>
        public PositiveMoney GetTotal()
        {
            if (this.Count == 0)
            {
                return new PositiveMoney(0, new Currency(string.Empty));
            }

            PositiveMoney total = new PositiveMoney(0, this.First().Amount.Currency);

            return this.Aggregate(total, (current, credit) =>
                new PositiveMoney(current.Amount + credit.Amount.Amount, current.Currency));
        }
    }
}
