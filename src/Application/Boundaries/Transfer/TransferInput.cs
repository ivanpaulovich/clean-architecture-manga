namespace Application.Boundaries.Transfer
{
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Transfer Input Message.
    /// </summary>
    public sealed class TransferInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferInput"/> class.
        /// </summary>
        /// <param name="originAccountId">Origin Account Id.</param>
        /// <param name="destinationAccountId">Destination Account Id.</param>
        /// <param name="amount">Positive amount.</param>
        public TransferInput(
            AccountId originAccountId,
            AccountId destinationAccountId,
            PositiveMoney amount)
        {
            OriginAccountId = originAccountId;
            DestinationAccountId = destinationAccountId;
            Amount = amount;
        }

        /// <summary>
        /// Gets Origin Account Id.
        /// </summary>
        public AccountId OriginAccountId { get; }

        /// <summary>
        /// Gets Destination Account Id.
        /// </summary>
        public AccountId DestinationAccountId { get; }

        /// <summary>
        /// Gets the Amount.
        /// </summary>
        public PositiveMoney Amount { get; }
    }
}
