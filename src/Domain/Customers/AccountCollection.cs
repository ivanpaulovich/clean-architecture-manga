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
            _accountIds = new List<AccountId>();
        }

        public void Add(IEnumerable<AccountId> accounts)
        {
            foreach (var account in accounts)
            {
                Add(account);
            }
        }

        public void Add(AccountId accountId) => _accountIds.Add(accountId);

        public IReadOnlyCollection<AccountId> GetAccountIds()
        {
            IReadOnlyCollection<AccountId> accountIds = new ReadOnlyCollection<AccountId>(_accountIds);
            return accountIds;
        }
    }
}
