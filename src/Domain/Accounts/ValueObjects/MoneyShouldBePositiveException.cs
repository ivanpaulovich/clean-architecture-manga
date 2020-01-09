namespace Domain.Accounts.ValueObjects
{
    /// <summary>
    /// Money Should Be Positive Exception.
    /// </summary>
    public sealed class MoneyShouldBePositiveException : DomainException
    {
        internal MoneyShouldBePositiveException(string message)
            : base(message)
        {
        }
    }
}
