namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;
    using System;

    public sealed class Debit : IEntity, ITransaction
    {
        public Guid Id { get; }
        public Guid AccountId { get; }
        public Amount Amount { get; }
        public string Description
        {
            get { return "Debit"; }
        }
        public DateTime TransactionDate { get; }

        public Debit(Guid id, Guid accountId, Amount amount, DateTime transactionDate)
        {
            Id = id;
            AccountId = accountId;
            Amount = amount;
            TransactionDate = transactionDate;
        }

        public Debit(Guid accountId, Amount amount)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            Amount = amount;
            TransactionDate = DateTime.UtcNow;
        }
    }
}
