namespace Manga.Application.Boundaries.Transfer
{
    using System;
    using Manga.Application.Exceptions;
    using Manga.Domain.ValueObjects;

    public sealed class TransferInput
    {
        public Guid OriginAccountId { get; }
        public Guid DestinationAccountId { get; }
        public PositiveAmount Amount { get; }

        public TransferInput(Guid originAccountId, Guid destinationAccountId, PositiveAmount amount)
        {
            if (originAccountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(originAccountId)} cannot be empty.");
            }

            if (destinationAccountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(destinationAccountId)} cannot be empty.");
            }

            if (amount == null)
            {
                throw new InputValidationException($"{nameof(amount)} cannot be null.");
            }

            OriginAccountId = originAccountId;
            DestinationAccountId = destinationAccountId;
            Amount = amount;
        }
    }
}