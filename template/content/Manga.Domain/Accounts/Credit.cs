namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;
    using System;

    public sealed class Credit : IEntity, ITransaction
    {
        public Guid Id { get; private set; }
        public Guid AccountId { get; private set; }
        public Amount Amount { get; private set; }
        public string Description
        {
            get { return "Credit"; }
        }
        public DateTime TransactionDate { get; private set; }

        private Credit() { }

        public static Credit Load(Guid id, Guid accountId, Amount amount, DateTime transactionDate)
        {
            Credit credit = new Credit();
            credit.Id = id;
            credit.AccountId = accountId;
            credit.Amount = amount;
            credit.TransactionDate = transactionDate;
            return credit;
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
