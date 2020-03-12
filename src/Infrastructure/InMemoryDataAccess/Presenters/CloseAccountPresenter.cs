namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.CloseAccount;

    /// <summary>
    ///     Close Account Presenter.
    /// </summary>
    public sealed class CloseAccountPresenter : IOutputPort
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CloseAccountPresenter" /> class.
        /// </summary>
        public CloseAccountPresenter()
        {
            this.ClosedAccounts = new Collection<CloseAccountOutput>();
            this.NotFounds = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        /// <summary>
        ///     Gets the ClosedAccounts.
        /// </summary>
        /// <value></value>
        public Collection<CloseAccountOutput> ClosedAccounts { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> Errors { get; }

        public void Standard(CloseAccountOutput output)
        {
            this.ClosedAccounts.Add(output);
        }

        public void NotFound(string message)
        {
            this.NotFounds.Add(message);
        }

        public void WriteError(string message)
        {
            this.Errors.Add(message);
        }
    }
}
