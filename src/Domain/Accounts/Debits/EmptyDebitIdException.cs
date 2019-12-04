namespace Domain.Accounts.Debits
{
    public sealed class EmptyDebitIdException : DomainException
    {
        internal EmptyDebitIdException(string message)
            : base(message)
        {
        }
    }
}
