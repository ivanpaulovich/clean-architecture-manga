// <copyright file="CreditsCollection.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Credits
{
    using System.Collections.Generic;
    using System.Linq;
    using ValueObjects;

    /// <summary>
    ///     Credits
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#first-class-collections">
    ///         First-Class
    ///         Collection Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class CreditsCollection : List<ICredit>
    {
        /// <summary>
        ///     Gets Total amount.
        /// </summary>
        /// <returns>Positive amount.</returns>
        public PositiveMoney GetTotal()
        {
            PositiveMoney total = new PositiveMoney(0);

            return this.Aggregate(total, (current, credit) => credit.Sum(current));
        }
    }
}
