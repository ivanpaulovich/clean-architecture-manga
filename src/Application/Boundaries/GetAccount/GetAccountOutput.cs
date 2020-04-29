// <copyright file="GetAccountOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetAccount
{
    using Domain.Accounts;

    /// <summary>
    ///     Get Account Details Output Message.
    /// </summary>
    public sealed class GetAccountOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountOutput" /> class.
        /// </summary>
        /// <param name="account">Account object.</param>
        public GetAccountOutput(IAccount account) => this.Account = account;

        /// <summary>
        ///     Gets the Account.
        /// </summary>
        public IAccount Account { get; }
    }
}
