namespace Manga.Application.Boundaries.Transfer
{
    using System;
    using Manga.Application.Exceptions;
    using Manga.Domain.ValueObjects;

    public sealed class TransferInput
    {
        public Guid OriginAccountId { get; }
        public Guid DestinationAccountId { get; }
        public PositiveMoney Amount { get; }

        public TransferInput(Guid originAccountId, Guid destinationAccountId, PositiveMoney amount)
        {
            if (originAccountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(originAccountId)} cannot be empty.");
            }

            if (destinationAccountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(destinationAccountId)} cannot be empty.");
            }

            OriginAccountId = originAccountId;
            DestinationAccountId = destinationAccountId;
            Amount = amount;
        }
    }
}
