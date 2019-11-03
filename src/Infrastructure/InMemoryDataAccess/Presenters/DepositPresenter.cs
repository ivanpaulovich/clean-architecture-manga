namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.Deposit;

    public sealed class DepositPresenter : IOutputPort
    {
        public Collection<DepositOutput> Deposits { get; }
        public Collection<string> NotFounds { get; }

        public DepositPresenter()
        {
            Deposits = new Collection<DepositOutput>();
            NotFounds = new Collection<string>();
        }

        public void Standard(DepositOutput output)
        {
            Deposits.Add(output);
        }

        public void NotFound(string message)
        {
            NotFounds.Add(message);
        }
    }
}