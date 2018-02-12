namespace Manga.Domain.Customers.Accounts
{
    public class AccountNotFoundException : DomainException
    {
        public AccountNotFoundException(string message)
            : base(message)
        { }
    }
}
