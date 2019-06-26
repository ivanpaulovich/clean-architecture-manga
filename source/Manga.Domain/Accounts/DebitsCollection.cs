namespace Manga.Domain.Accounts
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Manga.Domain.ValueObjects;

    public sealed class DebitsCollection
    {
        private readonly IList<IDebit> _debits;

        public DebitsCollection()
        {
            _debits = new List<IDebit>();
        }

        public DebitsCollection(IList<Debit> debits) : this()
        {
            foreach (var debit in debits)
                Add(debit);
        }

        public void Add(IDebit debit)
        {
            _debits.Add(debit);
        }

        public IReadOnlyCollection<IDebit> GetTransactions()
        {
            IReadOnlyCollection<IDebit> transactions = new ReadOnlyCollection<IDebit>(_debits);
            return transactions;
        }

        public PositiveAmount GetTotal()
        {
            PositiveAmount total = new PositiveAmount(0);

            foreach (IDebit debit in _debits)
            {
                total = debit.Sum(total);
            }

            return total;
        }
    }
}