namespace Domain.ValueObjects
{
    public sealed class EmptyAccountIdException : DomainException
    {
        internal EmptyAccountIdException(string message)
            : base(message)
        {
        }
    }
}