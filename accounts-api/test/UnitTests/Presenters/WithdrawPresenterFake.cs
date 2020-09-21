namespace UnitTests.Presenters
{
    using Application.Services;
    using Application.UseCases.Withdraw;
    using Domain;
    using Domain.Debits;

    public sealed class WithdrawPresenterFake : IOutputPort
    {
        public Account? Account { get; private set; }
        public Debit? Debit { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool OutOfFundsOutput { get; private set; }

        void IOutputPort.Invalid(Notification notification) => this.InvalidOutput = true;
        void IOutputPort.NotFound() => this.NotFoundOutput = true;
        void IOutputPort.OutOfFunds() => this.OutOfFundsOutput = true;

        public void Ok(Debit debit, Account account)
        {
            this.Account = account;
            this.Debit = debit;
        }
    }
}
