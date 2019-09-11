namespace Manga.Application.Boundaries.Withdraw
{
    using System;
    using Manga.Application.Exceptions;
    using Manga.Domain.ValueObjects;

    public sealed class WithdrawInput
    {
        public Guid AccountId { get; }
        public PositiveMoney Amount { get; }

        public WithdrawInput(Guid accountId, PositiveMoney amount)
        {
            if (accountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(accountId)} cannot be empty.");
            }

            if (amount == null)
            {
                throw new InputValidationException($"{nameof(amount)} cannot be null.");
            }

            AccountId = accountId;
            Amount = amount;
        }
    }
}