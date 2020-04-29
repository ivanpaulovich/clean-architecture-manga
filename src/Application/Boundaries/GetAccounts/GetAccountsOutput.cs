// <copyright file="GetAccountDetailsOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetAccounts
{
    using System.Collections.Generic;
    using Domain.Accounts;

    /// <summary>
    ///     Get Account Details Output Message.
    /// </summary>
    public sealed class GetAccountsOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountsOutput" /> class.
        /// </summary>
        /// <param name="accounts">Accounts list.</param>
        public GetAccountsOutput(IList<IAccount> accounts) => this.Accounts = accounts;

        /// <summary>
        ///     Gets the Account.
        /// </summary>
        public IList<IAccount> Accounts { get; }
    }
}
