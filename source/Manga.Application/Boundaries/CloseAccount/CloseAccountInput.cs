namespace Manga.Application.Boundaries.CloseAccount
{
    using System;
    using Manga.Application.Exceptions;

    public sealed class CloseAccountInput
    {
        public Guid AccountId { get; }

        public CloseAccountInput(Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(accountId)} cannot be empty.");
            }
            
            AccountId = accountId;
        }
    }
}