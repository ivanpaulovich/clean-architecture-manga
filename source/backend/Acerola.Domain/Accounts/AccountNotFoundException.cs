namespace Acerola.Domain.Accounts
{
    public class AccountNotFoundException : DomainException
    {
        public AccountNotFoundException(string message)
            : base(message)
        { }
    }
}
