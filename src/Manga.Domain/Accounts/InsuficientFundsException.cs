namespace Manga.Domain.Accounts
{
    public sealed class InsuficientFundsException : DomainException
    {
        internal InsuficientFundsException(string message)
            : base(message)
        { }
    }
}
