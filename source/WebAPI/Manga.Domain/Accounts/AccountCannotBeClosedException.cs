namespace Manga.Domain.Accounts
{
    public class AccountCannotBeClosedException : DomainException
    {
        public AccountCannotBeClosedException(string message)
            : base(message)
        { }
    }
}
