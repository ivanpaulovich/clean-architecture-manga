namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.Withdraw;

    public sealed class WithdrawPresenter : IOutputPort
    {
        public WithdrawPresenter()
        {
            this.Withdrawals = new Collection<WithdrawOutput>();
            this.NotFounds = new Collection<string>();
            this.OutOfBalances = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        public Collection<WithdrawOutput> Withdrawals { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> OutOfBalances { get; }

        public Collection<string> Errors { get; }

        public void Standard(WithdrawOutput output)
        {
            this.Withdrawals.Add(output);
        }

        public void NotFound(string message)
        {
            this.NotFounds.Add(message);
        }

        public void OutOfBalance(string message)
        {
            this.OutOfBalances.Add(message);
        }

        public void WriteError(string message)
        {
            this.Errors.Add(message);
        }
    }
}
