namespace Domain.Customers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Accounts <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#first-class-collections">First-Class Collection Design Pattern</see>.
    /// </summary>
    public sealed class AccountCollection
    {
        private readonly IList<AccountId> _accountIds;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCollection"/> class.
        /// </summary>
        public AccountCollection()
        {
            this._accountIds = new List<AccountId>();
        }

        /// <summary>
        /// Adds Accounts.
        /// </summary>
        /// <param name="accounts">Accounts list.</param>
        public void Add(IEnumerable<AccountId> accounts)
        {
            foreach (var account in accounts)
            {
                this.Add(account);
            }
        }

        /// <summary>
        /// Add a single account.
        /// </summary>
        /// <param name="accountId">AccountId.</param>
        public void Add(AccountId accountId) => this._accountIds.Add(accountId);

        /// <summary>
        /// Gets the AccountIds.
        /// </summary>
        /// <returns>ReadOnlyCollection.</returns>
        public IReadOnlyCollection<AccountId> GetAccountIds()
        {
            IReadOnlyCollection<AccountId> accountIds = new ReadOnlyCollection<AccountId>(this._accountIds);
            return accountIds;
        }
    }
}
