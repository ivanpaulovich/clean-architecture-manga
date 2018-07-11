namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;
    using System;

    public interface ITransaction
    {
        Amount Amount { get; }
        string Description { get; }
        DateTime TransactionDate { get; }
    }
}
