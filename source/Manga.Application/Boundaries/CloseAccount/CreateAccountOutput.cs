namespace Manga.Application.Boundaries.CloseAccount
{
    using System;
    using Manga.Domain.Accounts;

    public sealed class CreateAccountOutput
    {
        public Guid AccountId { get; }

        public CreateAccountOutput(IAccount account)
        {
            AccountId = account.Id;
        }
    }
}