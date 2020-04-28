// <copyright file="IAccountRepository.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Credits;
    using Customers.ValueObjects;
    using Debits;
    using ValueObjects;

    /// <summary>
    ///     Account
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#repository">
    ///         Repository
    ///         Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<IAccount> GetAccount(AccountId accountId);

        /// <summary>
        ///     Gets an Account.
        /// </summary>
        /// <param name="customerId">CustomerId.</param>
        /// <returns>An Account instance.</returns>
        Task<IList<IAccount>> GetBy(CustomerId customerId);

        /// <summary>
        ///     Adds an Account.
        /// </summary>
        /// <param name="account">Account object.</param>
        /// <param name="credit">Credit object.</param>
        /// <returns>Task.</returns>
        Task Add(IAccount account, ICredit credit);

        /// <summary>
        ///     Updates an Account.
        /// </summary>
        /// <param name="account">Account object.</param>
        /// <param name="credit">Credit object.</param>
        /// <returns>Task.</returns>
        Task Update(IAccount account, ICredit credit);

        /// <summary>
        ///     Updates the Account.
        /// </summary>
        /// <param name="account">Account object.</param>
        /// <param name="debit">Debit object.</param>
        /// <returns>Task.</returns>
        Task Update(IAccount account, IDebit debit);

        /// <summary>
        ///     Deletes the Account.
        /// </summary>
        /// <param name="account">Account object.</param>
        /// <returns>Task.</returns>
        Task Delete(IAccount account);
    }
}
