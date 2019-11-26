namespace Application.Boundaries.Withdraw
{
    using Domain.ValueObjects;

    public sealed class WithdrawInput : IUseCaseInput
    {
        public WithdrawInput(
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