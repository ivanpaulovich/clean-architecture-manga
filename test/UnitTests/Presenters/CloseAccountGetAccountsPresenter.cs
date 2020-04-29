namespace UnitTests.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.CloseAccount;

    /// <summary>
    ///     Close Account Presenter.
    /// </summary>
    public sealed class CloseAccountGetAccountsPresenter : ICloseAccountOutputPort
    {
        /// <summary>
        ///     Gets the ClosedAccounts.
        /// </summary>
        /// <value></value>
        public Collection<CloseAccountOutput> ClosedAccounts { get; } = new Collection<CloseAccountOutput>();

        public Collection<string> NotFounds { get; } = new Collection<string>();

        public Collection<string> Errors { get; } = new Collection<string>();

        public void Standard(CloseAccountOutput output) => this.ClosedAccounts.Add(output);

        public void NotFound(string message) => this.NotFounds.Add(message);

        public void WriteError(string message) => this.Errors.Add(message);
    }
}
