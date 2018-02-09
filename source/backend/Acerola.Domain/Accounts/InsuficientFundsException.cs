namespace Acerola.Domain.Accounts
{
    public class InsuficientFundsException : DomainException
    {
        public InsuficientFundsException(string message)
            : base(message)
        { }
    }
}
