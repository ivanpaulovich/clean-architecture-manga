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

        public IReadOnlyCollection<IDebit> GetTransactions()
        {
            IReadOnlyCollection<IDebit> transactions = new ReadOnlyCollection<IDebit>(_debits);
            return transactions;
        }

        public void Add(IDebit transaction)
        {
            _debits.Add(transaction);
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