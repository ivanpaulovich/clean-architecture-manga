namespace Domain.Accounts.ValueObjects
{
    public sealed class EmptyAccountIdException : DomainException
    {
        internal EmptyAccountIdException(string message)
            : base(message)
        {
        }
    }
}
