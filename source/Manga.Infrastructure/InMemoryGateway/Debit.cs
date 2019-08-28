namespace Manga.Infrastructure.InMemoryGateway
{
    using System;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public class Debit : Manga.Domain.Accounts.Debit
    {
        public Guid AccountId { get; protected set; }

        protected Debit() { }

        public Debit(IAccount account, PositiveAmount amountToWithdraw)
        {
            this.AccountId = account.Id;
            this.Amount = amountToWithdraw;
        }
    }
}