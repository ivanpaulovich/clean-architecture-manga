namespace Manga.Domain.Accounts
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.ValueObjects;

    public class Account : IAccount
    {
        public Guid Id { get; protected set; } 
        public Guid CustomerId { get; protected set; }
        private CreditsCollection _credits = new CreditsCollection();
        private DebitsCollection _debits = new DebitsCollection();

        private Account() { }

        public Account(Guid customerId)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
        }

        public ICredit Deposit(Amount amount)
        {
            Credit credit = new Credit(Id, amount);
            _credits.Add(credit);
            return credit;
        }

        public IDebit Withdraw(Amount amount)
        {
            if (GetCurrentBalance() < amount)
                return null;

            Debit debit = new Debit(Id, amount);
            _debits.Add(debit);
            return debit;
        }

        public bool CanBeClosed()
        {
            return GetCurrentBalance() > 0;
        }

        public Amount GetCurrentBalance()
        {
            Amount totalAmount = _credits.GetTotal() - _debits.GetTotal();
            return totalAmount;
        }

        public IReadOnlyCollection<ICredit> GetCredits()
        {
            var credits = _credits.GetTransactions();
            return credits;
        }

        public IReadOnlyCollection<IDebit> GetDebits()
        {
            var debits = _debits.GetTransactions();
            return debits;
        }
    }
}