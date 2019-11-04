namespace Application.Boundaries.Withdraw
{
    using System;
    using Exceptions;
    using Domain.ValueObjects;

    public sealed class WithdrawInput : IUseCaseInput
    {
        public Guid AccountId { get; }
        public PositiveMoney Amount { get; }

        public WithdrawInput(Guid accountId, PositiveMoney amount)
        {
            if (accountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(accountId)} cannot be empty.");
            }

            AccountId = accountId;
            Amount = amount;
        }
    }
}