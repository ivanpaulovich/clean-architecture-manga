// <copyright file="DepositGetAccountsPresenter.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace UnitTests.Presenters
{
    using Application.Services;
    using Application.UseCases.Deposit;
    using Domain.Accounts;
    using Domain.Accounts.Credits;

    /// <summary>
    ///     Deposit Presenter.
    /// </summary>
    public sealed class DepositPresenterFake : IOutputPort
    {
        public Account? Account { get; private set; }
        public Credit? Credit { get; private set; }
        public bool IsNotFound { get; private set; }
        public Notification? ModelState { get; private set; }

        public void Invalid(Notification modelState) => this.ModelState = modelState;

        public void Ok(Credit credit, Account account)
        {
            this.Credit = credit;
            this.Account = account;
        }

        public void NotFound() => this.IsNotFound = true;
    }
}
