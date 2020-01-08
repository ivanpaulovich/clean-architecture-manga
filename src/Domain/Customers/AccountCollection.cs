namespace Domain.Customers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Domain.Accounts.ValueObjects;

    public sealed class AccountCollection
    {
        private readonly IList<AccountId> _accountIds;

        public AccountCollection()
        {
            this._accountIds = new List<AccountId>();
        }

        public void Add(IEnumerable<AccountId> accounts)
        {
            foreach (var account in accounts)
            {
                this.Add(account);
            }
        }

        public void Add(AccountId accountId) => this._accountIds.Add(accountId);

        public IReadOnlyCollection<AccountId> GetAccountIds()
        {
            IReadOnlyCollection<AccountId> accountIds = new ReadOnlyCollection<AccountId>(this._accountIds);
            return accountIds;
        }
    }
}
