namespace UnitTests.Presenters
{
    using System;
    using Application.Services;
    using Application.UseCases.Withdraw;
    using Domain.Accounts;
    using Domain.Accounts.Debits;

    public sealed class WithdrawPresenterFake : IOutputPort
    {
        public Account? Account { get; private set; }
        public Debit? Debit { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid(Notification notification) => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void OutOfFunds() => throw new NotImplementedException();

        public void Ok(Debit debit, Account account)
        {
            this.Account = account;
            this.Debit = debit;
        }
    }
}
