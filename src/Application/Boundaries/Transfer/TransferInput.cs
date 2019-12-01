namespace Application.Boundaries.Transfer
{
    using Domain.Accounts.ValueObjects;

    public sealed class TransferInput : IUseCaseInput
    {
        public TransferInput(
            AccountId originAccountId,
            AccountId destinationAccountId,
            PositiveMoney amount)
        {
            OriginAccountId = originAccountId;
            DestinationAccountId = destinationAccountId;
            Amount = amount;
        }

        public AccountId OriginAccountId { get; }

        public AccountId DestinationAccountId { get; }

        public PositiveMoney Amount { get; }
    }
}
