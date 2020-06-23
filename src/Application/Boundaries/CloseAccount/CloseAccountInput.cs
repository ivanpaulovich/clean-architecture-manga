// <copyright file="CloseAccountInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.CloseAccount
{
    using System;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Close Account Input Message.
    /// </summary>
    public sealed class CloseAccountInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CloseAccountInput" /> class.
        /// </summary>
        /// <param name="accountId">Account Id.</param>
        public CloseAccountInput(Guid accountId) => this.AccountId = new AccountId(accountId);

        /// <summary>
        ///     Gets AccountId.
        /// </summary>
        public AccountId AccountId { get; }
    }
}
