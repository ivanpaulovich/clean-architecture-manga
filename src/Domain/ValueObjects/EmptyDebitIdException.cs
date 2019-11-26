namespace Domain.ValueObjects
{
    public sealed class EmptyDebitIdException : DomainException
    {
        internal EmptyDebitIdException(string message)
            : base(message)
        {
        }
    }
}