// <copyright file="GetAccountsInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccounts
{
    using Services;

    /// <summary>
    ///     Get Accounts Input Message.
    /// </summary>
    public sealed class GetAccountsInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountsInput" /> class.
        /// </summary>
        public GetAccountsInput() => this.ModelState = new Notification();

        internal Notification ModelState { get; }
    }
}
