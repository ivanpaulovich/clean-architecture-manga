namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TransactionCollection : ICollection<Transaction>
    {
        private List<Transaction> _items;
        public IReadOnlyCollection<Transaction> Items
        {
            get
            {
                return _items.AsReadOnly();
            }
            private set
            {
                _items = value.ToList();
            }
        }

        public int Count => _items.Count;

        public bool IsReadOnly => true;

        public TransactionCollection()
        {
            _items = new List<Transaction>();
        }

        internal Amount GetCurrentBalance()
        {
            Amount totalAmount = new Amount(0);

            //
            // TODO: Think on a better Strategy
            //

            foreach (var item in Items)
            {
                if (item is Debit)
                    totalAmount -= item.Amount;

                if (item is Credit)
                    totalAmount += item.Amount;
            }

            return totalAmount;
        }

        public void Add(Transaction item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(Transaction item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(Transaction[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(Transaction item)
        {
            return _items.Remove(item);
        }

        public IEnumerator<Transaction> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
