namespace Domain.Security
{
    public sealed class UserNotFoundException : DomainException
    {
        public UserNotFoundException(string message)
            : base(message)
        {
        }
    }
}
