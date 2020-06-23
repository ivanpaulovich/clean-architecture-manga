// <copyright file="GetAccountInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetAccount
{
    using System;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Get Account Details Input Message.
    /// </summary>
    public sealed class GetAccountInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountInput" /> class.
        /// </summary>
        /// <param name="accountId">Account Id.</param>
        public GetAccountInput(Guid accountId) => this.AccountId = new AccountId(accountId);

        /// <summary>
        ///     Gets the AccountId.
        /// </summary>
        public AccountId AccountId { get; }
    }
}
