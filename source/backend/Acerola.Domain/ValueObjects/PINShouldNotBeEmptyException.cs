namespace Acerola.Domain.ValueObjects
{
    public class PINShouldNotBeEmptyException : DomainException
    {
        public PINShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
