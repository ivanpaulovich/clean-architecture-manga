namespace Manga.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public class Debit : Manga.Domain.Accounts.Debit
    {
        public Guid AccountId { get; protected set; }

        protected Debit() { }

        public Debit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate)
        {
            this.AccountId = account.Id;
            this.Amount = amountToWithdraw;
            this.TransactionDate = transactionDate;
        }
    }
}