namespace Manga.Infrastructure.InMemoryDataAccess
{
    using System;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public class Credit : Manga.Domain.Accounts.Credit
    {
        public Guid AccountId { get; protected set; }

        protected Credit() { }
        
        public Credit(IAccount account, PositiveAmount amountToDeposit)
        {
            this.AccountId = account.Id;
            this.Amount = amountToDeposit;
        }
    }
}