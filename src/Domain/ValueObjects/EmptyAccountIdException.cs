namespace Domain.ValueObjects
{
    internal sealed class EmptyAccountIdException : DomainException
    {
        internal EmptyAccountIdException(string message)
            : base(message)
        {
        }
    }
}