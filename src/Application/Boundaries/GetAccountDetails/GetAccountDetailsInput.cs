namespace Application.Boundaries.GetAccountDetails
{
    using System;
    using Exceptions;

    public sealed class GetAccountDetailsInput
    {
        public Guid AccountId { get; }

        public GetAccountDetailsInput(Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(accountId)} cannot be empty.");
            }

            AccountId = accountId;
        }
    }
}