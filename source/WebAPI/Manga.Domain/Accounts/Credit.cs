namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;
    using System;

    public sealed class Credit : IEntity, ITransaction
    {
        public Guid Id { get; }
        public Guid AccountId { get; }
        public Amount Amount { get; }
        public string Description
        {
            get { return "Credit"; }
        }
        public DateTime TransactionDate { get; }

        public Credit(Guid id, Guid accountId, Amount amount, DateTime transactionDate)
        {
            Id = id;
            AccountId = accountId;
            Amount = amount;
            TransactionDate = transactionDate;
        }

        public Credit(Guid accountId, Amount amount)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            Amount = amount;
            TransactionDate = DateTime.UtcNow;
        }
    }
}
