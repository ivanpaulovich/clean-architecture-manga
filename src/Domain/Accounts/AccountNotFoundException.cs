namespace Domain.Accounts
{
    /// <summary>
    /// Account Not Found Exception.
    /// </summary>
    public sealed class AccountNotFoundException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public AccountNotFoundException(string message)
            : base(message)
        {
        }
    }
}
