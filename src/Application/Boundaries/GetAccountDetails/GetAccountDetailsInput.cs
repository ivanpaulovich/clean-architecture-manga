namespace Application.Boundaries.GetAccountDetails
{
    using System;
    using Application.Exceptions;
    using Domain.ValueObjects;

    public sealed class GetAccountDetailsInput : IUseCaseInput
    {
        public GetAccountDetailsInput(Guid accountId)
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
