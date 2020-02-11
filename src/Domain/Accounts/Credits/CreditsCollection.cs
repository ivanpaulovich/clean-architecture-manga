// <copyright file="CreditsCollection.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Credits
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using ValueObjects;

    /// <summary>
    ///     Credits
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#first-class-collections">
    ///         First-Class
    ///         Collection Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class CreditsCollection
    {
        private readonly IList<ICredit> credits;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CreditsCollection" /> class.
        /// </summary>
        public CreditsCollection()
        {
            this.credits = new List<ICredit>();
        }

        /// <summary>
        ///     Adds a list of credits.
        /// </summary>
        /// <typeparam name="T">Some ICredit implementation.</typeparam>
        /// <param name="credits">The list of credits.</param>
        public void Add<T>(IEnumerable<T> credits)
            where T : ICredit
        {
            if (credits is null)
                throw new ArgumentNullException(nameof(credits));

            foreach (var credit in credits)
            {
                if (credit is null)
                    throw new ArgumentNullException(nameof(credits));

                this.Add(credit);
            }
        }

        /// <summary>
        ///     Adds a Credit.
        /// </summary>
        /// <param name="credit">ICredit implementation.</param>
        public void Add(ICredit credit) => this.credits.Add(credit);

        /// <summary>
        ///     List Transactions.
        /// </summary>
        /// <returns>ReadOnly Transactions.</returns>
        public IReadOnlyCollection<ICredit> GetTransactions()
        {
            var transactions = new ReadOnlyCollection<ICredit>(this.credits);
            return transactions;
        }

        /// <summary>
        ///     Gets Total amount.
        /// </summary>
        /// <returns>Positive amount.</returns>
        public PositiveMoney GetTotal()
        {
            PositiveMoney total = new PositiveMoney(0);

            foreach (ICredit credit in this.credits)
            {
                total = credit.Sum(total);
            }

            return total;
        }
    }
}
