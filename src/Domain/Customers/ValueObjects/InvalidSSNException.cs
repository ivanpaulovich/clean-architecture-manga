namespace Domain.Customers.ValueObjects
{
    internal sealed class InvalidSSNException : DomainException
    {
        internal InvalidSSNException(string message)
            : base(message)
        {
        }
    }
}
