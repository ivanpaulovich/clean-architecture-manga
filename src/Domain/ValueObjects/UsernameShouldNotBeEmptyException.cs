namespace Domain.ValueObjects
{
    public sealed class UsernameShouldNotBeEmptyException : DomainException
    {
        internal UsernameShouldNotBeEmptyException(string message) : base(message) { }
    }
}
