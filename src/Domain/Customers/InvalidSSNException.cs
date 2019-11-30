namespace Domain.Customers
{
    internal sealed class InvalidSSNException : DomainException
    {
        internal InvalidSSNException(string message)
            : base(message)
        {
        }
    }
}
