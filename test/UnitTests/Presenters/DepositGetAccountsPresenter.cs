// <copyright file="DepositGetAccountsPresenter.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace UnitTests.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.Deposit;

    /// <summary>
    ///     Deposit Presenter.
    /// </summary>
    public sealed class DepositGetAccountsPresenter : IDepositGetAccountsOutputPort
    {
        /// <summary>
        /// </summary>
        public DepositGetAccountsPresenter()
        {
            this.Deposits = new Collection<DepositOutput>();
            this.NotFounds = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        public Collection<DepositOutput> Deposits { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> Errors { get; }

        public void Standard(DepositOutput output)
        {
            this.Deposits.Add(output);
        }

        public void NotFound(string message)
        {
            this.NotFounds.Add(message);
        }

        public void WriteError(string message)
        {
            this.Errors.Add(message);
        }
    }
}
