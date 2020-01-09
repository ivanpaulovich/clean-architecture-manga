namespace Domain.Accounts.ValueObjects
{
    /// <summary>
    /// Empty Account Id Exception.
    /// </summary>
    public sealed class EmptyAccountIdException : DomainException
    {
        internal EmptyAccountIdException(string message)
            : base(message)
        {
        }
    }
}
