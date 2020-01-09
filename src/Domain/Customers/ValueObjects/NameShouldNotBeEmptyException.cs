namespace Domain.Customers.ValueObjects
{
    /// <summary>
    /// Name Should Not Be Empty Exception.
    /// </summary>
    public sealed class NameShouldNotBeEmptyException : DomainException
    {
        internal NameShouldNotBeEmptyException(string message)
            : base(message)
        {
        }
    }
}
