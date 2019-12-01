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
            _debits = new List<IDebit>();
        }

        public void Add<T>(IEnumerable<T> debits)
        where T : IDebit
        {
            foreach (var debit in debits)
            {
                Add(debit);
            }
        }

        public void Add(IDebit debit) => _debits.Add(debit);

        public IReadOnlyCollection<IDebit> GetTransactions()
        {
            IReadOnlyCollection<IDebit> transactions = new ReadOnlyCollection<IDebit>(_debits);
            return transactions;
        }

        public PositiveMoney GetTotal()
        {
            PositiveMoney total = new PositiveMoney(0);

            foreach (IDebit debit in _debits)
            {
                total = debit.Sum(total);
            }

            return total;
        }
    }
}
