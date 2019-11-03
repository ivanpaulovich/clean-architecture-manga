namespace Application.Boundaries.Deposit
{
    using System;
    using Application.Exceptions;
    using Domain.ValueObjects;

    public sealed class DepositInput
    {
        public Guid AccountId { get; }
        public PositiveMoney Amount { get; }

        public DepositInput(Guid accountId, PositiveMoney amount)
        {
            if (accountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(accountId)} cannot be empty.");
            }

            this.AccountId = accountId;
            this.Amount = amount;
        }
    }
}