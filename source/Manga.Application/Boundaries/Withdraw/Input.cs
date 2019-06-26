namespace Manga.Application.Boundaries.Withdraw
{
    using System;
    using Manga.Domain.ValueObjects;

    public sealed class Input
    {
        public Guid AccountId { get; }
        public PositiveAmount Amount { get; }

        public Input(Guid accountId, PositiveAmount amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}