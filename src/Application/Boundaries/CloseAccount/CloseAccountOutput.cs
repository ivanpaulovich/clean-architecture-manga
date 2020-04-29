// <copyright file="CloseAccountOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.CloseAccount
{
    using System;
    using Domain.Accounts;

    /// <summary>
    ///     Close Account Output Message.
    /// </summary>
    public sealed class CloseAccountOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CloseAccountOutput" /> class.
        /// </summary>
        /// <param name="account">IAccount object.</param>
        public CloseAccountOutput(IAccount account) =>
            this.Account = account ?? throw new ArgumentNullException(nameof(account));

        /// <summary>
        ///     Gets Account.
        /// </summary>
        public IAccount Account { get; }
    }
}
