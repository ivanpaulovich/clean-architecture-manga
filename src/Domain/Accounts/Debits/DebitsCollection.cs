namespace Domain.Accounts.Debits
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Debits <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#first-class-collections">First-Class Collection Design Pattern</see>.
    /// </summary>
    public sealed class DebitsCollection
    {
        private readonly IList<IDebit> _debits;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebitsCollection"/> class.
        /// </summary>
        public DebitsCollection()
        {
            this._debits = new List<IDebit>();
        }

        /// <summary>
        /// Adds a list of debits.
        /// </summary>
        /// <typeparam name="T">An IDebit implementation.</typeparam>
        /// <param name="debits">Debits List.</param>
        public void Add<T>(IEnumerable<T> debits)
            where T : IDebit
        {
            foreach (var debit in debits)
            {
                this.Add(debit);
            }
        }

        /// <summary>
        /// Adds a Debit.
        /// </summary>
        /// <param name="debit">Debit instance.</param>
        public void Add(IDebit debit) => this._debits.Add(debit);

        /// <summary>
        /// Gets readonly transactions.
        /// </summary>
        /// <returns>Transactions.</returns>
        public IReadOnlyCollection<IDebit> GetTransactions()
        {
            IReadOnlyCollection<IDebit> transactions = new ReadOnlyCollection<IDebit>(this._debits);
            return transactions;
        }

        /// <summary>
        /// Gets Total amount.
        /// </summary>
        /// <returns>Total.</returns>
        public PositiveMoney GetTotal()
        {
            PositiveMoney total = new PositiveMoney(0);

            foreach (IDebit debit in this._debits)
            {
                total = debit.Sum(total);
            }

            return total;
        }
    }
}
