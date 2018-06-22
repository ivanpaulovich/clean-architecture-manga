namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public sealed class TransactionCollection : Collection<ITransaction>
    {
        public ITransaction GetLastTransaction()
        {
            ITransaction transaction = Items[Items.Count - 1];
            return transaction;
        }

        public void Add(IEnumerable<ITransaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                Items.Add(transaction);
            }
        }

        public Amount GetCurrentBalance()
        {
            Amount totalAmount = 0;

            foreach (var item in Items)
            {
                if (item is Debit)
                    totalAmount = totalAmount - item.Amount;

                if (item is Credit)
                    totalAmount = totalAmount + item.Amount;
            }

            return totalAmount;
        }
    }
}
