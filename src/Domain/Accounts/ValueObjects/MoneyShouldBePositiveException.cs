namespace Domain.Accounts.ValueObjects
{
    public sealed class MoneyShouldBePositiveException : DomainException
    {
        internal MoneyShouldBePositiveException(string message)
            : base(message)
        {
        }
    }
}
