// <copyright file="GetAccountInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccount
{
    using Domain.ValueObjects;
    using Services;
    using System;

    /// <summary>
    ///     Get Account Details Input Message.
    /// </summary>
    internal sealed class GetAccountInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountInput" /> class.
        /// </summary>
        /// <param name="accountId">Account Id.</param>
        internal GetAccountInput(Guid accountId)
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
