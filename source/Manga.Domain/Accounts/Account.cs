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

        public ICredit Deposit(PositiveAmount amount)
        {
            var credit = new Credit(Id, amount);
            _credits.Add(credit);
            return credit;
        }

        public IDebit Withdraw(PositiveAmount amount)
        {
            if (GetCurrentBalance().LessThan(amount))
                return null;

            var debit = new Debit(Id, amount);
            _debits.Add(debit);
            return debit;
        }

        public bool IsClosingAllowed()
        {
            return GetCurrentBalance().IsZero();
        }

        public Amount GetCurrentBalance()
        {
            var totalCredits = _credits
                .GetTotal();

            var totalDebits = _debits
                .GetTotal();

            var totalAmount = totalCredits
                .Subtract(totalDebits);

            return totalAmount;
        }

        public IReadOnlyCollection<ICredit> GetCredits()
        {
            var credits = _credits
                .GetTransactions();
            return credits;
        }

        public IReadOnlyCollection<IDebit> GetDebits()
        {
            var debits = _debits
                .GetTransactions();
            return debits;
        }

        public void Load(IList<Credit> credits, IList<Debit> debits)
        {
            _credits = new CreditsCollection(credits);
            _debits = new DebitsCollection(debits);
        }
    }
}