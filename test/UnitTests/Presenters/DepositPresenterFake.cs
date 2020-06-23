// <copyright file="DepositGetAccountsPresenter.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace UnitTests.Presenters
{
    using Application.Boundaries.Deposit;

    /// <summary>
    ///     Deposit Presenter.
    /// </summary>
    public sealed class DepositPresenterFake : IDepositOutputPort
    {
        public DepositOutput? StandardOutput { get; private set; }

        public string? NotFoundOutput { get; private set; }

        public string? ErrorOutput { get; private set; }

        public void Standard(DepositOutput output) => this.StandardOutput = output;

        public void NotFound(string message) => this.NotFoundOutput = message;

        public void WriteError(string message) => this.ErrorOutput = message;
    }
}
