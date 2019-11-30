namespace Application.Boundaries.Deposit
{
    using Domain.Accounts;

    public sealed class DepositInput : IUseCaseInput
    {
        public DepositInput(
            AccountId accountId,
            PositiveMoney amount)
        {
            AccountId = accountId;
            Amount = amount;
        }

        public AccountId AccountId { get; }

        public PositiveMoney Amount { get; }
    }
}
