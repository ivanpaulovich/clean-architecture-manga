namespace Domain.Accounts.Debits
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Domain.Accounts.ValueObjects;

    public sealed class DebitsCollection
    {
        private readonly IList<IDebit> _debits;

        public DebitsCollection()
        {
            this._debits = new List<IDebit>();
        }

        public void Add<T>(IEnumerable<T> debits)
        where T : IDebit
        {
            foreach (var debit in debits)
            {
                this.Add(debit);
            }
        }

        public void Add(IDebit debit) => this._debits.Add(debit);

        public IReadOnlyCollection<IDebit> GetTransactions()
        {
            IReadOnlyCollection<IDebit> transactions = new ReadOnlyCollection<IDebit>(this._debits);
            return transactions;
        }

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
