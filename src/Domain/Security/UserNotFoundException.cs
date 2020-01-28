namespace Domain.Security
{
    /// <summary>
    /// User Not Found Exception.
    /// </summary>
    public sealed class UserNotFoundException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public UserNotFoundException(string message)
            : base(message)
        {
        }
    }
}
