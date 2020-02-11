// <copyright file="AccountCollection.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Accounts.ValueObjects;

    /// <summary>
    ///     Accounts
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#first-class-collections">
    ///         First-Class
    ///         Collection Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class AccountCollection
    {
        private readonly IList<AccountId> accountIds;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountCollection" /> class.
        /// </summary>
        public AccountCollection()
        {
            this.accountIds = new List<AccountId>();
        }

        /// <summary>
        ///     Adds Accounts.
        /// </summary>
        /// <param name="accounts">Accounts list.</param>
        public void Add(IEnumerable<AccountId> accounts)
        {
            if (accounts is null)
                throw new ArgumentNullException(nameof(accounts));

            foreach (var account in accounts)
            {
                this.Add(account);
            }
        }

        /// <summary>
        ///     Add a single account.
        /// </summary>
        /// <param name="accountId">AccountId.</param>
        public void Add(AccountId accountId) => this.accountIds.Add(accountId);

        /// <summary>
        ///     Gets the AccountIds.
        /// </summary>
        /// <returns>ReadOnlyCollection.</returns>
        public IReadOnlyCollection<AccountId> GetAccountIds()
        {
            IReadOnlyCollection<AccountId> accountIds = new ReadOnlyCollection<AccountId>(this.accountIds);
            return accountIds;
        }
    }
}
