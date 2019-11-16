namespace Application.Boundaries.Transfer
{
    using System;
    using Domain.ValueObjects;
    using Exceptions;

    public sealed class TransferInput : IUseCaseInput
    {
        public Guid OriginAccountId { get; }
        public Guid DestinationAccountId { get; }
        public PositiveMoney Amount { get; }

        public TransferInput(
            Guid originAccountId,
            Guid destinationAccountId,
            PositiveMoney amount)
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