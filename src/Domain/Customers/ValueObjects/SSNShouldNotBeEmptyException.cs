namespace Domain.Customers.ValueObjects
{
    /// <summary>
    /// SSN Should Not Be Empty Exception.
    /// </summary>
    public sealed class SSNShouldNotBeEmptyException : DomainException
    {
        internal SSNShouldNotBeEmptyException(string message)
            : base(message)
        {
        }
    }
}
