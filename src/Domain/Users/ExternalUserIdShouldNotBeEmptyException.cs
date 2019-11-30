namespace Domain.Users
{
    public sealed class ExternalUserIdShouldNotBeEmptyException : DomainException
    {
        internal ExternalUserIdShouldNotBeEmptyException(string message)
            : base(message)
        {
        }
    }
}
