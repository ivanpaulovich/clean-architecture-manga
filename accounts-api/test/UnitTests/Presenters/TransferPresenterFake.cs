namespace UnitTests.Presenters
{
    using Application.Services;
    using Application.UseCases.Transfer;
    using Domain;
    using Domain.Credits;
    using Domain.Debits;

    public sealed class TransferPresenterFake : IOutputPort
    {
        public Account? OriginAccount { get; private set; }
        public Account? DestinationAccount { get; private set; }
        public Credit? Credit { get; private set; }
        public Debit? Debit { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool OutOfFundsOutput { get; private set; }

        void IOutputPort.Invalid(Notification notification) => this.InvalidOutput = true;
        void IOutputPort.NotFound() => this.NotFoundOutput = true;

        void IOutputPort.Ok(Account originAccount, Debit debit, Account destinationAccount, Credit credit)
        {
            this.OriginAccount = originAccount;
            this.Debit = debit;
            this.DestinationAccount = destinationAccount;
            this.Credit = credit;
        }

        void IOutputPort.OutOfFunds() => this.OutOfFundsOutput = true;
    }
}
