namespace Application.UseCases.Withdraw
{
    using Domain;
    using Domain.Debits;

    public sealed class WithdrawPresenter : IOutputPort
    {
        public Account? Account { get; private set; }
        public Debit? Debit { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool OutOfFundsOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void OutOfFunds() => this.OutOfFundsOutput = true;
        public void Ok(Debit debit, Account account)
        {
            this.Account = account;
            this.Debit = debit;
        }
    }
}
