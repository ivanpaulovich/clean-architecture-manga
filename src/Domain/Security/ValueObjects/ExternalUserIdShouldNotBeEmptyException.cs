namespace Domain.Security.ValueObjects
{
    /// <summary>
    /// External User Id Should Not Be Empty Exception.
    /// </summary>
    public sealed class ExternalUserIdShouldNotBeEmptyException : DomainException
    {
        internal ExternalUserIdShouldNotBeEmptyException(string message)
            : base(message)
        {
        }
    }
}
