namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;
    using System;
    using System.Collections.ObjectModel;

    public sealed class Account : IEntity, IAggregateRoot
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public ReadOnlyCollection<ITransaction> Transactions
        {
            get
            {
                ReadOnlyCollection<ITransaction> readOnly = new ReadOnlyCollection<ITransaction>(_transactions);
                return readOnly;
            }
        }

        private TransactionCollection _transactions;

        public Account(Guid id, Guid customerId, TransactionCollection transactions)
        {
            Id = id;
            _transactions = transactions;
            CustomerId = customerId;
        }

        public Account(Guid customerId)
        {
            Id = Guid.NewGuid();
            _transactions = new TransactionCollection();
            CustomerId = customerId;
        }

        public void Deposit(Amount amount)
        {
            Credit credit = new Credit(Id, amount);
            _transactions.Add(credit);
        }

        public void Withdraw(Amount amount)
        {
            if (_transactions.GetCurrentBalance() < amount)
                throw new InsuficientFundsException($"The account {Id} does not have enough funds to withdraw {amount}.");

            Debit debit = new Debit(Id, amount);
            _transactions.Add(debit);
        }

        public void Close()
        {
            if (_transactions.GetCurrentBalance() > 0)
                throw new AccountCannotBeClosedException($"The account {Id} can not be closed because it has funds.");
        }

        public Amount GetCurrentBalance()
        {
            Amount totalAmount = _transactions.GetCurrentBalance();
            return totalAmount;
        }

        public ITransaction GetLastTransaction()
        {
            ITransaction transaction = _transactions.GetLastTransaction();
            return transaction;
        }
    }
}
