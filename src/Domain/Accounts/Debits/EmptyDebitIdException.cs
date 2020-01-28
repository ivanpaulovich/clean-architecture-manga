namespace Domain.Accounts.Debits
{
    /// <summary>
    /// Empty DebitId Exception.
    /// </summary>
    public sealed class EmptyDebitIdException : DomainException
    {
        internal EmptyDebitIdException(string message)
            : base(message)
        {
        }
    }
}
