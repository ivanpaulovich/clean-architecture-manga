namespace UnitTests.Presenters
{
    using Application.Boundaries.CloseAccount;

    /// <summary>
    ///     Close Account Presenter.
    /// </summary>
    public sealed class CloseAccountPresenterFake : ICloseAccountOutputPort
    {
        /// <summary>
        ///     Gets the ClosedAccount.
        /// </summary>
        /// <value></value>
        public CloseAccountOutput? StandardOutput { get; private set; }

        /// <summary>
        ///     Gets the NotFound.
        /// </summary>
        /// <value></value>
        public string? NotFoundOutput { get; private set; }

        /// <summary>
        ///     Gets the Error.
        /// </summary>
        /// <value></value>
        public string? ErrorOutput { get; private set; }

        /// <summary>
        ///     Standard Output
        /// </summary>
        /// <param name="output">Output message.</param>
        public void Standard(CloseAccountOutput output) => this.StandardOutput = output;

        /// <summary>
        ///     Not Found
        /// </summary>
        /// <param name="message">Output message.</param>
        public void NotFound(string message) => this.NotFoundOutput = message;

        /// <summary>
        ///     Error
        /// </summary>
        /// <param name="message">Error message.</param>
        public void WriteError(string message) => this.ErrorOutput = message;
    }
}
