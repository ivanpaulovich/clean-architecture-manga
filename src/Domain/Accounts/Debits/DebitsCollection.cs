// <copyright file="DebitsCollection.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Debits
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using ValueObjects;

    /// <summary>
    ///     Debits
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#first-class-collections">
    ///         First-Class
    ///         Collection Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class DebitsCollection
    {
        private readonly IList<IDebit> debits;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DebitsCollection" /> class.
        /// </summary>
        public DebitsCollection()
        {
            this.debits = new List<IDebit>();
        }

        /// <summary>
        ///     Adds a list of debits.
        /// </summary>
        /// <typeparam name="T">An IDebit implementation.</typeparam>
        /// <param name="debits">Debits List.</param>
        public void Add<T>(IEnumerable<T> debits)
            where T : IDebit
        {
            if (debits is null)
                throw new ArgumentNullException(nameof(debits));

            foreach (var debit in debits)
            {
                if (debit is null)
                    throw new ArgumentNullException(nameof(debits));

                this.Add(debit);
            }
        }

        /// <summary>
        ///     Adds a Debit.
        /// </summary>
        /// <param name="debit">Debit instance.</param>
        public void Add(IDebit debit) => this.debits.Add(debit);

        /// <summary>
        ///     Gets readonly transactions.
        /// </summary>
        /// <returns>Transactions.</returns>
        public IReadOnlyCollection<IDebit> GetTransactions()
        {
            IReadOnlyCollection<IDebit> transactions = new ReadOnlyCollection<IDebit>(this.debits);
            return transactions;
        }

        /// <summary>
        ///     Gets Total amount.
        /// </summary>
        /// <returns>Total.</returns>
        public PositiveMoney GetTotal()
        {
            PositiveMoney total = new PositiveMoney(0);

            foreach (IDebit debit in this.debits)
            {
                total = debit.Sum(total);
            }

            return total;
        }
    }
}
