// <copyright file="IAccountRepository.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain;

using System.Collections.Generic;
using System.Threading.Tasks;
using Credits;
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
    /// </summary>
    /// <param name="externalUserId"></param>
    /// <returns></returns>
    Task<IList<Account>> GetAccounts(string externalUserId);

    /// <summary>
    ///     Adds an Account.
    /// </summary>
    /// <param name="account">Account object.</param>
    /// <param name="credit">Credit object.</param>
    /// <returns>Task.</returns>
    Task Add(Account account, Credit credit);

    /// <summary>
    ///     Updates an Account.
    /// </summary>
    /// <param name="account">Account object.</param>
    /// <param name="credit">Credit object.</param>
    /// <returns>Task.</returns>
    Task Update(Account account, Credit credit);

    /// <summary>
    ///     Updates the Account.
    /// </summary>
    /// <param name="account">Account object.</param>
    /// <param name="debit">Debit object.</param>
    /// <returns>Task.</returns>
    Task Update(Account account, Debit debit);

    /// <summary>
    ///     Deletes the Account.
    /// </summary>
    /// <param name="accountId">Account Id.</param>
    /// <returns>Task.</returns>
    Task Delete(AccountId accountId);

    /// <summary>
    ///     Finds an Account.
    /// </summary>
    /// <param name="accountId">Account Id.</param>
    /// <param name="externalUserId">External User Id.</param>
    /// <returns></returns>
    Task<IAccount> Find(AccountId accountId, string externalUserId);
}
