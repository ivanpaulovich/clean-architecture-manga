namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;
    using System;
    using System.Collections.Generic;

    public sealed class Account : IEntity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public IReadOnlyCollection<ITransaction> GetTransactions()
        {
            IReadOnlyCollection<ITransaction> readOnly = _transactions.GetTransactions();
            return readOnly;
        }

        private TransactionCollection _transactions;

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

        private Account() { }

        public static Account Load(Guid id, Guid customerId, TransactionCollection transactions)
        {
            Account account = new Account();
            account.Id = id;
            account.CustomerId = customerId;
            account._transactions = transactions;
            return account;
        }
    }
}
