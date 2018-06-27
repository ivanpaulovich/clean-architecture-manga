namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;
    using System;

    public sealed class Debit : IEntity, ITransaction
    {
        public Guid Id { get; private set; }
        public Guid AccountId { get; private set; }
        public Amount Amount { get; private set; }
        public string Description
        {
            get { return "Debit"; }
        }
        public DateTime TransactionDate { get; private set; }

        private Debit() { }

        public static Debit Load(Guid id, Guid accountId, Amount amount, DateTime transactionDate)
        {
            Debit debit = new Debit();
            debit.Id = id;
            debit.AccountId = accountId;
            debit.Amount = amount;
            debit.TransactionDate = transactionDate;
            return debit;
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
