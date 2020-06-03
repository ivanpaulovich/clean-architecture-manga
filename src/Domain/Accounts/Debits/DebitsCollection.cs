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
            PositiveMoney total = new PositiveMoney(0);

            return this.Aggregate(total, (current, debit) => debit.Sum(current));
        }
    }
}
