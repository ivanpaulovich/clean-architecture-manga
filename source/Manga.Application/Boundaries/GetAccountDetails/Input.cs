namespace Manga.Application.Boundaries.GetAccountDetails
{
    using System;

    public sealed class Input
    {
        public Guid AccountId { get; }

        public Input(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}