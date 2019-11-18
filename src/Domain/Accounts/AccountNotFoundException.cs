namespace Domain.Accounts
{
    public sealed class AccountNotFoundException : DomainException
    {
        public AccountNotFoundException(string message)
            : base(message)
        {
        }
    }
}
