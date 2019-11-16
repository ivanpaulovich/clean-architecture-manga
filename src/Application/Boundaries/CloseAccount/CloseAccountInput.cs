namespace Application.Boundaries.CloseAccount
{
    using System;
    using Domain.ValueObjects;
    using Exceptions;

    public sealed class CloseAccountInput : IUseCaseInput
    {
        public Guid AccountId { get; }

        public CloseAccountInput(
            Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(accountId)} cannot be empty.");
            }

            AccountId = accountId;
        }
    }
}