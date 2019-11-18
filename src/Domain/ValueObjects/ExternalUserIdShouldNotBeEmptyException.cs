namespace Domain.ValueObjects
{
    public sealed class ExternalUserIdShouldNotBeEmptyException : DomainException
    {
        internal ExternalUserIdShouldNotBeEmptyException(string message)
            : base(message)
        {
        }
    }
}