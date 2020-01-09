namespace Domain.Accounts.Credits
{
    /// <summary>
    /// Empty CreditId Exception.
    /// </summary>
    public sealed class EmptyCreditIdException : DomainException
    {
        internal EmptyCreditIdException(string message)
            : base(message)
        {
        }
    }
}
