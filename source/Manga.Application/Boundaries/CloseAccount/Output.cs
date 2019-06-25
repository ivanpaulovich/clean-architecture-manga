namespace Manga.Application.Boundaries.CloseAccount
{
    using System;
    using Manga.Domain.Accounts;

    public sealed class Output
    {
        public Guid AccountId { get; }

        public Output(IAccount account)
        {
            AccountId = account.Id;
        }
    }
}