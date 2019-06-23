namespace Manga.Domain.Accounts
{
    using System;
    using Manga.Domain.ValueObjects;

    public class Debit : IDebit
    {
        public Guid Id { get; protected set; }
        public Guid AccountId { get; protected set; }
        public PositiveAmount Amount { get; protected set; }
        public string Description
        {
            get { return "Debit"; }
        }
        public DateTime TransactionDate { get; protected set; } 

        private Debit() { }

        public Debit(Guid accountId, PositiveAmount amount)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            Amount = amount;
            TransactionDate = DateTime.UtcNow;
        }

        public PositiveAmount Sum(PositiveAmount amount)
        {
            return Amount.Add(amount);
        }
    }
}