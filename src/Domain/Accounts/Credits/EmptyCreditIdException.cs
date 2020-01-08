namespace Domain.Accounts.Credits
{
    /// <summary>
    /// Empty CreditId Exception.
    /// </summary>
    public sealed class EmptyCreditIdException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyCreditIdException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        internal EmptyCreditIdException(string message)
            : base(message)
        {
        }
    }
}
