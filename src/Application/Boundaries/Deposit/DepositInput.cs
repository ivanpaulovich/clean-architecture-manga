namespace Application.Boundaries.Deposit
{
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Deposit Input Message.
    /// </summary>
    public sealed class DepositInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepositInput"/> class.
        /// </summary>
        /// <param name="accountId">AccountId.</param>
        /// <param name="amount">Positive amount to deposit.</param>
        public DepositInput(
            AccountId accountId,
            PositiveMoney amount)
        {
            AccountId = accountId;
            Amount = amount;
        }

        /// <summary>
        /// Gets AccountId.
        /// </summary>
        public AccountId AccountId { get; }

        /// <summary>
        /// Gets the Amount.
        /// </summary>
        public PositiveMoney Amount { get; }
    }
}
