// <copyright file="AccountCollection.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers
{
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
    public sealed class AccountCollection : List<AccountId>
    {
        /// <summary>
        ///     Gets the AccountIds.
        /// </summary>
        /// <returns>ReadOnlyCollection.</returns>
        public IEnumerable<AccountId> GetAccountIds()
        {
            var accountIds = new ReadOnlyCollection<AccountId>(this);
            return accountIds;
        }
    }
}
