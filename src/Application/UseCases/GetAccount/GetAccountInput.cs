// <copyright file="GetAccountInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccount
{
    using System;
    using Domain.Accounts.ValueObjects;
    using Services;

    /// <summary>
    ///     Get Account Details Input Message.
    /// </summary>
    public sealed class GetAccountInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountInput" /> class.
        /// </summary>
        /// <param name="accountId">Account Id.</param>
        public GetAccountInput(Guid accountId)
        {
            this.ModelState = new Notification();

            if (accountId != Guid.Empty)
            {
                this.AccountId = new AccountId(accountId);
            }
            else
            {
                this.ModelState.Add(nameof(accountId), "AccountId is required.");
            }
        }

        internal AccountId AccountId { get; }
        internal Notification ModelState { get; }
    }
}
