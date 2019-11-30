namespace Domain.Customers
{
    public sealed class NameShouldNotBeEmptyException : DomainException
    {
        internal NameShouldNotBeEmptyException(string message)
            : base(message)
        {
        }
    }
}
