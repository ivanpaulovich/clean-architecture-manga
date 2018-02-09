namespace Acerola.Domain.ValueObjects
{
    public class AmountShouldBePositiveException : DomainException
    {
        public AmountShouldBePositiveException(string message)
            : base(message)
        { }
    }
}
