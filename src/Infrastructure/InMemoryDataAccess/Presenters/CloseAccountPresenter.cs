namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.CloseAccount;

    /// <summary>
    /// Close Account Presenter.
    /// </summary>
    public sealed class CloseAccountPresenter : IOutputPort
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloseAccountPresenter"/> class.
        /// </summary>
        public CloseAccountPresenter()
        {
            ClosedAccounts = new Collection<CloseAccountOutput>();
            NotFounds = new Collection<string>();
        }

        /// <summary>
        /// Gets the ClosedAccounts.
        /// </summary>
        /// <value></value>
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
