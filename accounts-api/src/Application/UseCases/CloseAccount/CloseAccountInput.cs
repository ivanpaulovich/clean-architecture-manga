// <copyright file="CloseAccountInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.CloseAccount
{
    using System;
    using Domain.ValueObjects;
    using Services;

    /// <summary>
    ///     Close Account Input Message.
    /// </summary>
    internal sealed class CloseAccountInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CloseAccountInput" /> class.
        /// </summary>
        /// <param name="accountId">Account Id.</param>
        internal CloseAccountInput(Guid accountId)
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
