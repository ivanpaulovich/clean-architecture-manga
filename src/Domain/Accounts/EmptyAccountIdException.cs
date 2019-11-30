namespace Domain.Accounts
{
    public sealed class EmptyAccountIdException : DomainException
    {
        internal EmptyAccountIdException(string message)
            : base(message)
        {
        }
    }
}
