namespace Manga.Application.Boundaries.Deposit
{
    using System;
    using Manga.Domain.ValueObjects;

    public sealed class Input
    {
        public Guid AccountId { get; }
        public PositiveAmount Amount { get; }

        public Input(Guid accountId, PositiveAmount amount)
        {
            this.AccountId = accountId;
            this.Amount = amount;
        }
    }
}