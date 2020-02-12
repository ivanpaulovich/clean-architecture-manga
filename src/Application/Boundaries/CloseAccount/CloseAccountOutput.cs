// <copyright file="CloseAccountOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.CloseAccount
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Close Account Output Message.
    /// </summary>
    public sealed class CloseAccountOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CloseAccountOutput" /> class.
        /// </summary>
        /// <param name="account">IAccount object.</param>
        public CloseAccountOutput(IAccount account)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            this.AccountId = account.Id;
        }

        /// <summary>
        ///     Gets AccountId.
        /// </summary>
        public AccountId AccountId { get; }
    }
}
