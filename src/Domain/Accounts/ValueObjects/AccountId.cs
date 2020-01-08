namespace Domain.Accounts.ValueObjects
{
    using System;

    public readonly struct AccountId
    {
        private readonly Guid _accountId;

        public AccountId(Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                throw new EmptyAccountIdException($"{nameof(accountId)} cannot be empty.");
            }

            this._accountId = accountId;
        }

        public override string ToString()
        {
            return this._accountId.ToString();
        }

        public Guid ToGuid() => this._accountId;
    }
}
