namespace Domain.Accounts.Credits
{
    public sealed class EmptyCreditIdException : DomainException
    {
        internal EmptyCreditIdException(string message)
            : base(message)
        {
        }
    }
}
