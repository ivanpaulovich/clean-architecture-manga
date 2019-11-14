namespace Domain.ValueObjects
{
    public sealed class TokenShouldNotBeEmptyException : DomainException
    {
        internal TokenShouldNotBeEmptyException(string message) : base(message) { }
    }
}
