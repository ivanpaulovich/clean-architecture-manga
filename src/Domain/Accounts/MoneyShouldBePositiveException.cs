namespace Domain.Accounts
{
    public sealed class MoneyShouldBePositiveException : DomainException
    {
        internal MoneyShouldBePositiveException(string message)
            : base(message)
        {
        }
    }
}
