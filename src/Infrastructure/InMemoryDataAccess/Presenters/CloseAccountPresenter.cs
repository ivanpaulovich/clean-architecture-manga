namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.CloseAccount;

    public sealed class CloseAccountPresenter : IOutputPort
    {
        public CloseAccountPresenter()
        {
            ClosedAccounts = new Collection<CloseAccountOutput>();
            NotFounds = new Collection<string>();
        }

        public Collection<CloseAccountOutput> ClosedAccounts { get; }

        public Collection<string> NotFounds { get; }

        public void Standard(CloseAccountOutput output)
        {
            ClosedAccounts.Add(output);
        }

        public void NotFound(string message)
        {
            NotFounds.Add(message);
        }
    }
}
