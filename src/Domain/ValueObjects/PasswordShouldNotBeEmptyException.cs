namespace Domain.ValueObjects
{
    public sealed class PasswordShouldNotBeEmptyException : DomainException
    {
        internal PasswordShouldNotBeEmptyException(string message)
            : base(message)
        {
        }
    }
}
