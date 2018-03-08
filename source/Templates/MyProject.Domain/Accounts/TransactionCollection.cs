namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;
    using System.Collections.Generic;
    using System.Linq;

    public class TransactionCollection
    {
        private List<Transaction> items;
        public IReadOnlyCollection<Transaction> Items
        {
            get
            {
                return items.AsReadOnly();
            }
            private set
            {
                items = value.ToList();
            }
        }

        public TransactionCollection()
        {
            items = new List<Transaction>();
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

        internal void Add(Transaction transaction)
        {
            items.Add(transaction);
        }
    }
}
