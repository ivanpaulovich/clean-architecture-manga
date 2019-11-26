namespace Domain.ValueObjects
{
    public sealed class EmptyCreditIdException : DomainException
    {
        internal EmptyCreditIdException(string message)
            : base(message)
        {
        }
    }
}