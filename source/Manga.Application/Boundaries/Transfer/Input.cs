namespace Manga.Application.Boundaries.Transfer
{
    using System;
    using Manga.Domain.ValueObjects;

    public sealed class Input
    {
        public Guid OriginAccountId { get; }
        public Guid DestinationAccountId { get; }
        public PositiveAmount Amount { get; }

        public Input(Guid originAccountId, Guid destinationAccountId, PositiveAmount amount)
        {
            OriginAccountId = originAccountId;
            DestinationAccountId = destinationAccountId;
            Amount = amount;
        }
    }
}