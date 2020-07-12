namespace UnitTests.Presenters
{
    using System;
    using Application.Services;
    using Application.UseCases.Transfer;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;

    public sealed class TransferPresenterFake : IOutputPort
    {
        public Account? OriginAccount { get; private set; }
        public Account? DestinationAccount { get; private set; }
        public Credit? Credit { get; private set; }
        public Debit? Debit { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid(Notification notification) => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;

        public void Ok(Account originAccount, Debit debit, Account destinationAccount, Credit credit)
        {
            this.OriginAccount = originAccount;
            this.Debit = debit;
            this.DestinationAccount = destinationAccount;
            this.Credit = credit;
        }

        public void OutOfFunds() => throw new NotImplementedException();
    }
}
