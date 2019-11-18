namespace Application.Boundaries.Deposit
{
    using System;
    using Application.Exceptions;
    using Domain.ValueObjects;

    public sealed class DepositInput : IUseCaseInput
    {
        public DepositInput(
            Guid accountId,
            PositiveMoney amount)
        {
            if (accountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(accountId)} cannot be empty.");
            }

            AccountId = accountId;
            Amount = amount;
        }

        public Guid AccountId { get; }

        public PositiveMoney Amount { get; }
    }
}
