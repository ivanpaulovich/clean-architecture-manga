namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;
    using System;

    public class Account : Entity, IAggregateRoot
    {
        public virtual Guid CustomerId { get; protected set; }
        public virtual int Version { get; protected set; }
        public virtual TransactionCollection Transactions { get; protected set; }

        protected Account()
        {
            Transactions = new TransactionCollection();
        }

        public Account(Guid customerId)
            : this()
        {
            CustomerId = customerId;
        }

        public void Deposit(Credit credit)
        {
            Transactions.Add(credit);
        }

        public void Withdraw(Debit debit)
        {
            if (Transactions.GetCurrentBalance() < debit.Amount)
                throw new InsuficientFundsException($"The account {Id} does not have enough funds to withdraw {debit.Amount}.");

            Transactions.Add(debit);
        }

        public void Close()
        {
            if (Transactions.GetCurrentBalance() > 0)
                throw new AccountCannotBeClosedException($"The account {Id} can not be closed because it has funds.");
        }

        public Amount GetCurrentBalance()
        {
            return Transactions.GetCurrentBalance();
        }
    }
}
