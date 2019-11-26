namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.Withdraw;

    public sealed class WithdrawPresenter : IOutputPort
    {
        public WithdrawPresenter()
        {
            Withdrawals = new Collection<WithdrawOutput>();
            NotFounds = new Collection<string>();
            OutOfBalances = new Collection<string>();
        }

        public Collection<WithdrawOutput> Withdrawals { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> OutOfBalances { get; }

        public void Standard(WithdrawOutput output)
        {
            Withdrawals.Add(output);
        }

        public void NotFound(string message)
        {
            NotFounds.Add(message);
        }

        public void OutOfBalance(string message)
        {
            OutOfBalances.Add(message);
        }
    }
}