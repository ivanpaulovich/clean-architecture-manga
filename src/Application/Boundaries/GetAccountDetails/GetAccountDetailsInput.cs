// <copyright file="GetAccountDetailsInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetAccountDetails
{
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Get Account Details Input Message.
    /// </summary>
    public sealed class GetAccountDetailsInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountDetailsInput" /> class.
        /// </summary>
        /// <param name="accountId">Account Id.</param>
        public GetAccountDetailsInput(AccountId accountId)
        {
            this.AccountId = accountId;
        }

        /// <summary>
        ///     Gets the AccountId.
        /// </summary>
        public AccountId AccountId { get; }
    }
}
