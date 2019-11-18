namespace Application.Boundaries.CloseAccount
{
    using System;
    using Application.Exceptions;
    using Domain.ValueObjects;

    public sealed class CloseAccountInput : IUseCaseInput
    {
        public CloseAccountInput(
            Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(accountId)} cannot be empty.");
            }

            AccountId = accountId;
        }

        public Guid AccountId { get; }
    }
}
