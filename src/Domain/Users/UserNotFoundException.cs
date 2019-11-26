namespace Domain.Users
{
    public sealed class UserNotFoundException : DomainException
    {
        public UserNotFoundException(string message)
            : base(message)
        {
        }
    }
}